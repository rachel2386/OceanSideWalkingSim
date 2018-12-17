using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
	private CameraEffect turnOnThermal;
	
	private Animator blackAnim;

	private bool triggered = false;

	private float timer = 0f;
	private float blackTimer = 0f;
	public float TotTime = 5f;

	//public GameObject robotUI;
	//public GameObject reticle;
	
	public Text guideText;
	 
	
	// Use this for initialization
	void Start ()
	{
		//robotUI = GameObject.Find("Canvas");
		if (Camera.main != null) 
			turnOnThermal = Camera.main.GetComponent<CameraEffect>();
		guideText = GameObject.Find("Text").GetComponent<Text>();
		
		blackAnim = GameObject.Find("black").GetComponent<Animator>();
	}

	private void Update()
	{
		
		if (triggered)
		{
			timer += Time.deltaTime;
			guideText.text = "SHUTTING DOWN..";
			//var textColor = guideText.color;
			//textColor.a = (Mathf.Lerp(1f,0f,timer/TotTime);
			turnOnThermal.m_Enable = true;
			turnOnThermal.m_ThermalHigh = Mathf.Lerp(0.8f,0f,timer/TotTime);
			turnOnThermal.m_BlurAmount = Mathf.Lerp(0.1f,1f,timer/TotTime);
			turnOnThermal.m_DimensionsX = Mathf.Lerp(1f,0f,timer/TotTime);
			turnOnThermal.m_DimensionsY = Mathf.Lerp(1f,0f,timer/TotTime);
			blackAnim.SetBool("ended",true);

			if (timer >= TotTime)
			{
				timer = TotTime;
				//float alpha= Mathf.Lerp(0,1,blackTimer/3f);
				//var blackImgColor = blackImg.color;
				//blackTimer+= Time.deltaTime;


			}
		}
	}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			triggered = true;
			
		}

		

	}
}
