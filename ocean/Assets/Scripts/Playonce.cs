using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playonce : MonoBehaviour{
	private AudioClip myAudio;
	private AudioSource myAS;
	private bool hasPlayed = false;

	void Start()
	{
		myAS = GetComponent<AudioSource>();

		myAudio = myAS.clip;

	}

	void Update()
	{

		Debug.Log("hasPlayed" + hasPlayed);
	}

	void OnTriggerEnter(Collider other){
			if (other.gameObject.tag.Equals("Player"))
			{
				if (!hasPlayed)
				{
					myAS.PlayOneShot(myAudio);
					Debug.Log(other.gameObject.name);
					hasPlayed = true;
					//Destroy(gameObject);
				}
				
					
		}
		}
	
}
