using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
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

	private bool generatorOn = false;
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

			if (timer <= 3)
			{
				
				if (!GetComponent<AudioSource>().isPlaying)
					GetComponent<AudioSource>().Play();
				sparkAnim.gameObject.SetActive(true);
				sparkAnim.SetBool("generatorOn",true);
				
				
				//sparkAnim playing
				
			}

			if (timer <= 1)
			{
				timer = 0;
				
				if(!BGAudio.isPlaying && !bgPlayed)
					BGAudio.Play();
					backGateAnim.SetBool("trashDisposed", true);
					bgPlayed = true;
				

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
