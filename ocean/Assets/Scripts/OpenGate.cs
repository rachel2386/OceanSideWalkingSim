using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class OpenGate : MonoBehaviour
{
	Animator myAnim;
	private GameObject[] itemsWTag;
	private Text CollectNum;

	// Use this for initialization
	void Start ()
	{
		myAnim = GetComponent<Animator>();
		CollectNum = GameObject.Find("Text").GetComponent<Text>();
		
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		itemsWTag = GameObject.FindGameObjectsWithTag("items");
		Debug.Log("itemsNum = " + itemsWTag.Length );
		if (itemsWTag.Length > 0)
		{
			CollectNum.text = "COLLECTIBLE REMAINING " + itemsWTag.Length;
		}

		if (itemsWTag.Length <= 0)
		{
			CollectNum.text = "COLLECTIBLE REMAINING : 0" ;
			CollectNum.color = Color.yellow;
			myAnim.SetBool("OpenGate",true);
		}
	}
	
}
