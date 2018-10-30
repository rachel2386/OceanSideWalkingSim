using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SocialPlatforms;


	


public class PickupItem : MonoBehaviour
{
	private Transform holder;
	private Transform player;
	private Rigidbody itemRB;
	private Transform itemTransform;
	private GameObject item;
	public Transform itemParent;
	private bool itemRotate = false;
	public bool pickedup = false;
	private Vector3 itemOffset;
	private Vector3 lastMousePos;
	private Vector2 rotateAxis;
	private float finalRotatespeed;
	private float tgtRotatespeed;
	private float smoother = 100;
	private float rotateSpeed = 0.1f;
	private float timeDuration =0.20f;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		holder = transform;
		item = GameObject.FindGameObjectWithTag("items");
		itemRB = item.GetComponent<Rigidbody>();
		itemTransform = item.transform;
		itemOffset = item.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log("pickedup=" + pickedup);
		

		if (pickedup)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("Collided with" + item.name);
				pickup();
				
			}
				
			if (Input.GetMouseButtonUp(0))
			{
					
				dropOff();
				
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
	}

	private void OnTriggerEnter(Collider other)
	{

		if (pickedup == false)
		{
			if (other.gameObject.tag.Equals("items"))
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
				if (other.gameObject.tag.Equals("items"))
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
		itemRotate = true;
		itemTransform.SetParent(holder);
		itemTransform.position = holder.position;
		itemTransform.rotation = holder.rotation;
		itemTransform.localScale = itemOffset;
		itemRB.useGravity = false;
		itemRB.isKinematic = true;
		itemRB.detectCollisions = false;
		
	
		//lastMousePos = Input.mousePosition;

		
		//item.GetComponent<Collider>().enabled = false;



	}

	void dropOff()
	{
		pickedup = false;
		itemRotate = false;
		itemTransform.SetParent(itemParent);
		//Vector3 holderWorldPos = itemTransform.InverseTransformPoint(holder.position);
		//Vector3 holderWorldRot = itemTransform.InverseTransformPoint(holder.eulerAngles);
		itemTransform.position = holder.position;
		itemTransform.eulerAngles = holder.eulerAngles;
;		itemTransform.localScale = itemOffset;
		itemRB.useGravity = true;
		itemRB.isKinematic = false;
		itemRB.detectCollisions = true;
		//item.GetComponent<Collider>().enabled = true;
		
	}
}
