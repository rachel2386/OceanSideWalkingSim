using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playonce : MonoBehaviour
{
	private AudioClip myAudio;

	private AudioSource myAS;

	private bool hasPlayed = false;
	
	// Use this for initialization
	void Start ()
	{
		myAS = GetComponent<AudioSource>();
		myAudio = myAS.clip;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log("hasPlayed" + hasPlayed);
	}

	void OnTriggerEnter(Collider other)
	{ if (other.gameObject.tag.Equals("Player"))
			if (!hasPlayed)
			{
				myAS.PlayOneShot(myAudio);
				//Debug.Log(other.gameObject.name);
				hasPlayed = true;
				
			}
	}
}
