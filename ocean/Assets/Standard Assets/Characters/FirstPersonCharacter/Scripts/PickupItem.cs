using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SocialPlatforms;


	


public class PickupItem : MonoBehaviour
{
	private Transform holder;
	private Rigidbody itemRB;
	private Transform itemTransform;
	
	
	private bool itemRotate = false;
	public bool pickedup = false;
	
	private Vector3 itemOffset;
	private Vector2 rotateAxis;
	private float finalRotatespeed;
	private float tgtRotatespeed;
	private float smoother = 50;
	private float rotateSpeed = 0.08f;
	private float timeDuration =0.20f;
	bool mousePressed = false;
	public Transform reticleTransform;
	public int trashCounter = 0;
	
	private Animator canAnim;
	private Animator gateAnim;
	
	// Use this for initialization
	void Start ()
	{
		canAnim = GameObject.Find("TrashCan").GetComponent<Animator>();
		//trashCan = GameObject.Find("Trash").transform;
		holder = GameObject.Find("objectHolder").transform;
		
		itemRB = GetComponent<Rigidbody>();
		itemTransform = transform;
		itemOffset = transform.localScale;
		
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log("pickedup=" + pickedup);
		Debug.Log("counter" + trashCounter);
		
		

		if (pickedup)
		{
			
			if (Input.GetMouseButtonUp(0))
			{
				Debug.Log("Collided with" + gameObject.name);
				pickup();
				mousePressed = true;

			}
			
		}
		
		if(mousePressed)
		{
			if (Input.GetMouseButtonUp(1))
			{
					
				onDestroy();
				trashCounter++;
				mousePressed = false;
			}
				
		}

			if (itemRotate)
			
			{
			
			//itemTransform.Rotate(180 * timeDuration*Time.deltaTime,180 * timeDuration*Time.deltaTime, 180 * timeDuration*Time.deltaTime,Space.Self);
			Vector2 mouseDir = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
				if(mouseDir.magnitude !=0)
				{rotateAxis = Vector2.Perpendicular(mouseDir);}
					
				if (mouseDir.magnitude == 0)
				{
					tgtRotatespeed = 0;
				}
				else
				{
					tgtRotatespeed = rotateSpeed;
				}
				
				finalRotatespeed += (tgtRotatespeed - finalRotatespeed) * 0.1f * Time.deltaTime * smoother;
				itemTransform.RotateAround((rotateAxis), Time.deltaTime * finalRotatespeed * smoother);
			}
		
		if (trashCounter >=3)
			OpenGate();
	}

	private void OnTriggerEnter(Collider other)
	{

		if (pickedup == false)
		{
			if (other.gameObject.tag.Equals("Player"))
			{
				pickedup = true;

			}

		}
	}
	
	private void OnTriggerExit(Collider other)
	{

		if (Input.GetMouseButton(0)==false)
		{
			if (pickedup == true)
			{
				if (other.gameObject.tag.Equals("Player"))
				{
					pickedup = false;

				}

			}
		}
		else
		{
			pickedup = true;
		}

	}
	
	








	void pickup()
	{
		
		
		if (Camera.main != null)
		{
			itemRotate = true;
			itemTransform.SetParent(holder);
			
			Vector3 reticleWorld = Camera.main.ScreenToWorldPoint(reticleTransform.position);//new Vector3(reticleTransform.position.x,reticleTransform.position.y,1f));
			reticleWorld.z = 0f;
			itemTransform.InverseTransformPoint(reticleWorld);
			itemTransform.localEulerAngles = new Vector3(0, 0, 0);//holder.rotation;)
			
			itemTransform.localScale = itemOffset;
			itemRB.useGravity = false;
			itemRB.isKinematic = true;
			itemRB.detectCollisions = false;
		}

		
		
	
		//lastMousePos = Input.mousePosition;

		
		//item.GetComponent<Collider>().enabled = false;



	}

	void dropOff()
	{
		pickedup = false;
		itemRotate = false;
		//itemTransform.SetParent(trashCan);
		
		//Vector3 holderWorldPos = itemTransform.InverseTransformPoint(holder.position);
		//Vector3 holderWorldRot = itemTransform.InverseTransformPoint(holder.eulerAngles);
		itemTransform.localPosition = Vector3.zero;
		itemTransform.localEulerAngles = (Vector3.zero);
		//itemTransform.eulerAngles = holder.eulerAngles;
;		itemTransform.localScale = itemOffset * 0.1f;
		itemRB.useGravity = false;
		itemRB.isKinematic = false;
		itemRB.detectCollisions = false;
		//item.GetComponent<Collider>().enabled = true;
		
	}

	void onDestroy()
	{
		Destroy(gameObject);
		canAnim.SetTrigger("trashIn");
		//canAnim.ResetTrigger("trashIn");
		
	}

	void OpenGate()
	{
		
			gateAnim.SetBool("openGate", true);
			
		

	}
}
