using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
	private CameraEffect turnOnThermal;

	private bool triggered = false;

	private float timer = 0f;

	public float TotTime = 5f;
	// Use this for initialization
	void Start ()
	{
		if (Camera.main != null) 
			turnOnThermal = Camera.main.GetComponent<CameraEffect>();
	}

	private void Update()
	{
		
		if (triggered)
		{
			timer += Time.deltaTime;

			turnOnThermal.m_Enable = true;
			turnOnThermal.m_Enable = false;
			turnOnThermal.m_Enable = true;
			turnOnThermal.m_Enable = false;
			turnOnThermal.m_Enable = true;
			turnOnThermal.m_Enable = false;
			turnOnThermal.m_Enable = true;
			turnOnThermal.m_ThermalHigh = Mathf.Lerp(0.8f,0f,timer/TotTime);
			turnOnThermal.m_BlurAmount = Mathf.Lerp(0.1f,1f,timer/TotTime);
			turnOnThermal.m_DimensionsX = Mathf.Lerp(1f,0f,timer/TotTime);
			turnOnThermal.m_DimensionsY = Mathf.Lerp(1f,0f,timer/TotTime);

			
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
