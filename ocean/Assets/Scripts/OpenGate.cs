using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
	Animator myAnim;
	private GameObject[] itemsWTag;

	// Use this for initialization
	void Start ()
	{
		myAnim = GetComponent<Animator>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		itemsWTag = GameObject.FindGameObjectsWithTag("items");
		Debug.Log("itemsNum = " + itemsWTag.Length );
		if (itemsWTag.Length <= 0)
		{
			
			myAnim.SetBool("OpenGate",true);
		}
	}
	
}
