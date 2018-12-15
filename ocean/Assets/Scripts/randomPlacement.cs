using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPlacement : MonoBehaviour {

	private float spawnTime = 0;

	public float multiplier = 4;
	//public float startZ = 0;
	//public float xLimit = 20;
	public int maxNum = 0;
	private Collider planeTransform;
	private Vector3 minBound;
	private Vector3 maxBound;
	private Vector3 ColCenter;
	
	
	

	// Use this for initialization
	void Start () {
		//after spawnTime, call MakeEnemy function
		//InvokeRepeating 
		var plane = GameObject.FindGameObjectsWithTag("Ground");
		var trashNum = GameObject.FindGameObjectsWithTag("trash");
		
		
		if(plane != null)
		{
			for(int i = 0; i < plane.Length; i++)
			{
				planeTransform = plane[i].GetComponent<MeshCollider>();
				minBound = planeTransform.bounds.min;
				maxBound = planeTransform.bounds.max;
				ColCenter = planeTransform.bounds.center;
			}
			
			if (trashNum.Length <= maxNum)
			{
				Invoke("MakeTrash", spawnTime);
			}
		}
		
		
		
		
		//plane = GameObject.FindGameObjectWithTag("Ground").transform;
	//	Debug.Log("planePos" + plane.position);
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void MakeTrash()
	{
		Vector3 planePos = ColCenter;//planeTransform.position;
		Vector3 planeScale = planeTransform.bounds.size;
		//Debug.Log("VplanePos" + planePos);
		var trashNum = GameObject.FindGameObjectsWithTag("trash");
		//planeWorldPos;
		//int maxNum = 50;
		GameObject newTrash = Instantiate(Resources.Load("Prefabs/LandFill")) as GameObject;
		
		// next two lines commented out because it reaches all depth of children 
		//Transform[] childs = newBottle.GetComponentsInChildren<Transform>();
		//GameObject randomObject = childs[Random.Range(0, childs.Length)].gameObject;
		
		// change transform of only first depth of children
		
		
		foreach (Transform childTrans in newTrash.transform)
		{
			
			
			childTrans.transform.position =

				new Vector3(Random.Range(maxBound.x, minBound.x),Random.Range(maxBound.y,minBound.y), Random.Range(maxBound.z,minBound.z)) * multiplier;
				/*new Vector3(Random.Range(planePos.x- (planeScale.x/2), 
						planePos.x + (planeScale.x/2)),
					planePos.y + 0.1f,
					Random.Range(planePos.z- (planeScale.z/2),
						planePos.z + (planeScale.z/2))) * multiplier;*/
			
			childTrans.transform.eulerAngles = new Vector3(90,0,Random.Range(0,360));
		}

		
		if (trashNum.Length <= maxNum)
			Invoke("MakeTrash", spawnTime);

	

	}


}
