using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityStandardAssets.Utility;

public class disposeTrash : MonoBehaviour
{
	private Animator trashAnim;
	// Use this for initialization
	void Start ()
	{
		trashAnim = GameObject.Find("TrashCan").GetComponent<Animator>();
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

					if (GetComponent<AudioSource>().isPlaying)
						GetComponent<AudioSource>().Play();

				}
			//}
		}
	}
}
