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
	private AudioSource gateOpenSound;
	bool soundPlayed = false;
	private bool shownText = false;

	// Use this for initialization
	void Start ()
	{
		myAnim = GetComponent<Animator>();
		CollectNum = GameObject.Find("Text").GetComponent<Text>();
		gateOpenSound = GetComponent<AudioSource>();


	}
	
	// Update is called once per frame
	void Update ()
	{
		
		itemsWTag = GameObject.FindGameObjectsWithTag("items");
		//Debug.Log("itemsNum = " + itemsWTag.Length );
		if (itemsWTag.Length > 0)
		{
			CollectNum.text = "COLLECTIBLE REMAINING: " + itemsWTag.Length + "/2000000000";
		}

		if (itemsWTag.Length <= 0)
		{

			if (!shownText)
			{
				CollectNum.text = "ENGINE ROOM ACTIVATED" ;
				CollectNum.color = Color.yellow;
				shownText = true;
			}
			
			myAnim.SetBool("OpenGate",true);
			if (!gateOpenSound.isPlaying && !soundPlayed)
			{
				gateOpenSound.Play();
				soundPlayed = true;
			}
		}
	}
	
}
