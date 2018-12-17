﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class disposeTrash : MonoBehaviour
{
	private Animator trashAnim;
	private Animator backGateAnim;
	private Animator sparkAnim;
	private Animator sparkAnim1;
	private Animator sparkAnim2;
	private Animator sparkAnim3;
	private AudioSource disposeSound;
	private AudioSource BGAudio;
	private bool bgPlayed = false;
	bool dumped =false;
	private AudioSource myaudio;
	private Text guideText;

	private bool generatorOn = false;
	private bool shownText=false;
	float timer =5f;
	// Use this for initialization
	void Start ()
	{
		trashAnim = GameObject.Find("TrashCan").GetComponent<Animator>();
		backGateAnim = GameObject.Find("BackGate").GetComponent<Animator>();
		sparkAnim = GameObject.Find("ElectricalSpark").GetComponent<Animator>();
	BGAudio = GameObject.Find("BackGate").GetComponent<AudioSource>();
		var tSounds = GameObject.Find("TrashCan").GetComponents<AudioSource>();
		disposeSound = tSounds[1];
		myaudio = GetComponent<AudioSource>();
		guideText = GameObject.Find("Text").GetComponent<Text>();
	}

	private void Update()
	{
		if (generatorOn)
		{
			if (disposeSound.isPlaying == false && dumped == false)
			{
				disposeSound.Play();
				dumped = true;
			}
			if(timer>0)
				timer -= Time.deltaTime;

			if (timer <= 3 && timer > 1)
			{
				
				if (!myaudio.isPlaying)
					myaudio.Play();
				sparkAnim.gameObject.SetActive(true);
				sparkAnim.SetBool("generatorOn",true);
				guideText.text = "CONVERTING ENERGY...";
				
				
				//sparkAnim playing
				
			}

			if (timer <= 1.5 && timer > 0)
			{
				guideText.text = "GENERATING ELECTRIC POWER... ";
			}

			if(timer<=0)
			{
				timer = 0;
				if(!BGAudio.isPlaying && !bgPlayed)
					BGAudio.Play();
					backGateAnim.SetBool("trashDisposed", true);
					bgPlayed = true;
				if (!shownText)
				{
					guideText.text = "PROCEED TO POWER STATION";
					shownText= true;
				}
				

			}

			
		}
	}

	// Update is called once per frame
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			//RaycastHit lookAtTube = new RaycastHit();
			//if (Physics.Raycast(other.gameObject.transform.position, other.gameObject.transform.forward, out lookAtTube,
			//	10f))
			//{
				if (Input.GetMouseButtonUp(0))
				{
					trashAnim.SetBool("trashDisposed", true);
				
					generatorOn = true;

				}
			//}
		}
	}
}
