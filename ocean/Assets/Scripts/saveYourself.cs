using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveYourself : MonoBehaviour
{
	private Rigidbody myRB;
	// Use this for initialization
	void Start ()
	{
		myRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("r"))
		{
			myRB.AddForce(new Vector3(1,30,1),ForceMode.Impulse);
		}
	}
}
