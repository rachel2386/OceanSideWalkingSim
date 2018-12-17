using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
	private Scene currentScene;
	private Ending gameEnded;
	private float timer = 3f;
	private Animator blackAnim;
	bool countDown = false;

	// Use this for initialization
	void Start()
	{
		currentScene = SceneManager.GetActiveScene();
		gameEnded = GameObject.Find("Ending").GetComponent<Ending>();
		blackAnim = GameObject.Find("black").GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update()
	{
		if (currentScene.buildIndex == 0)
		{
			if (Input.GetMouseButtonUp(0))
			{
				
				blackAnim.SetBool("ended",true);
				
				countDown = true;
				

			}

			if (countDown)
			{
				timer -= Time.deltaTime;
				if (timer <= 0)
				{
					SceneManager.LoadScene(1);
				}
			}
		}

		if (currentScene.buildIndex == 1)
		{
			if (Input.GetKeyDown("r"))
			{
				SceneManager.LoadScene(1);
			}
			
			if(gameEnded.GameEnded)
			{
				
				timer -= Time.deltaTime;
				if (timer <= 0)
				{
					SceneManager.LoadScene(0);
				}
				
				
			}
		}
		
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}
}
