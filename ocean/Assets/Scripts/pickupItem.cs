using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class pickupItem : MonoBehaviour
{
	private Transform holder;
	private Transform player;
	private Rigidbody itemRB;
	private Transform itemTransform;
	private GameObject item;
	private bool itemRotate = false;
	private bool pickedup = false;

	private float timeDuration =0.20f;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		holder = transform;
		item = GameObject.FindGameObjectWithTag("items");
		itemRB = item.GetComponent<Rigidbody>();
		itemTransform = item.transform;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log("pickedup=" + pickedup);
		if (itemRotate)
		{
			
			itemTransform.Rotate(180 * timeDuration*Time.deltaTime,180 * timeDuration*Time.deltaTime, 180 * timeDuration*Time.deltaTime,Space.Self);
		}

		if (pickedup)
		{
			if (Input.GetMouseButtonDown(0))
			{
				//Debug.Log("Collided with" + item.name);
				pickup();
			}
				
			if (Input.GetMouseButtonUp(0))
			{
					
				dropOff();
				
			}
			
			
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
		itemRB.useGravity = false;
		itemRB.isKinematic = true;
		itemRB.detectCollisions = false;
		//item.GetComponent<Collider>().enabled = false;



	}

	void dropOff()
	{
		pickedup = false;
		itemRotate = false;
		itemTransform.SetParent(null);
		itemTransform.position = holder.position;
		itemTransform.rotation = holder.rotation;
		itemRB.useGravity = true;
		itemRB.isKinematic = false;
		itemRB.detectCollisions = true;
		//item.GetComponent<Collider>().enabled = true;
		
	}
}
