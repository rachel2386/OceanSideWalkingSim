using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DifferentView : MonoBehaviour
{
    private GameObject city;

    private Animator[] cityAnims;
    float time = 0f;
    //private  cityAnims;
   // private MeshRenderer[] cityMesh;

    void Start()
    {
        city = GameObject.Find("buildings");
        //cityMesh = GetComponentsInChildren<MeshRenderer>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {

            RenderSettings.fog = false;
            //var city = GameObject.FindGameObjectsWithTag("building");
            foreach (Transform building in city.transform)
            {
                Animator buildAnim = building.gameObject.GetComponent<Animator>();
               
              // Destroy(buildAnim.gameObject);
               if(!buildAnim.GetBool("TurnOnCity"))
               {buildAnim.SetBool("TurnOnCity", true);}

               
              

            }
        }
    }


}
