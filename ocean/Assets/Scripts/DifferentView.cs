using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DifferentView : MonoBehaviour
{

    public Animator CityLights;
    

    void Start()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            CityLights.SetBool("TurnOnCity", true);
        }
     
    }


}
