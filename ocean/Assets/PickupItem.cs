﻿using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PickupItem : MonoBehaviour
{
    private Transform holder;
    private Rigidbody itemRB;
    private Transform itemTransform;
    public RigidbodyFirstPersonController playerScript;

    private bool itemRotate = false;
    public bool pickedup = false;

    private Vector3 itemOffset;
    private Vector2 rotateAxis;
    private float finalRotatespeed;
    private float tgtRotatespeed;
    private float smoother = 50;
    private float rotateSpeed = 0.08f;
    private float timeDuration = 0.20f;
    private bool _mousePressed = false;
    public Transform reticleTransform;


    private Animator canAnim;
    private Animator gateAnim;

    private AudioSource trashSound;

    // Use this for initialization
    void Start()
    {
        canAnim = GameObject.Find("TrashCan").GetComponent<Animator>();
        //trashCan = GameObject.Find("Trash").transform;
        holder = GameObject.Find("objectHolder").transform;

        var tSounds = GameObject.Find("TrashCan").GetComponents<AudioSource>();
        trashSound = tSounds[0];

        itemRB = GetComponent<Rigidbody>();
        itemTransform = transform;
        itemOffset = transform.localScale;

        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("pickedup=" + pickedup);


        if (pickedup)
        {
            if (Input.GetMouseButtonUp(0))
            {
                //Debug.Log("Collided with" + gameObject.name);
                pickup();
                playerScript.holdingItem = true; // disable mouse look
                _mousePressed = true;
            }
        }

        if (_mousePressed)
        {
            
            if (Input.GetMouseButtonUp(1))
            {
                playerScript.holdingItem = false; //enable mouselook
                onDestroy();
                if (!trashSound.isPlaying)
                    trashSound.Play();
                _mousePressed = false;
            }
        }

        if (itemRotate)

        {
            //itemTransform.Rotate(180 * timeDuration*Time.deltaTime,180 * timeDuration*Time.deltaTime, 180 * timeDuration*Time.deltaTime,Space.Self);
            Vector2 mouseDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (mouseDir.magnitude != 0)
            {
                rotateAxis = Vector2.Perpendicular(mouseDir);
            }

            if (mouseDir.magnitude == 0)
            {
                tgtRotatespeed = 0;
            }
            else
            {
                tgtRotatespeed = rotateSpeed;
            }

            finalRotatespeed += (tgtRotatespeed - finalRotatespeed) * 0.1f * Time.deltaTime * smoother;
            itemTransform.RotateAround((rotateAxis), Time.deltaTime * finalRotatespeed * smoother);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pickedup == false)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                pickedup = true;
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Input.GetMouseButton(0) == false)
        {
            if (pickedup == true)
            {
                if (other.gameObject.tag.Equals("Player"))
                {
                    pickedup = false;
                    
                }
            }
        }
        else
        {
            pickedup = true;
        }
    }


    void pickup()
    {
        if (Camera.main != null)
        {
            itemRotate = true;
            itemTransform.SetParent(holder);

            Vector3 reticleWorld =
                Camera.main.ScreenToWorldPoint(reticleTransform
                    .position); //new Vector3(reticleTransform.position.x,reticleTransform.position.y,1f));
            reticleWorld.z = 0f;
            itemTransform.InverseTransformPoint(reticleWorld);
            itemTransform.localEulerAngles = new Vector3(0, 0, 0); //holder.rotation;)

            itemTransform.localScale = itemOffset;
            itemRB.useGravity = false;
            itemRB.isKinematic = true;
            itemRB.detectCollisions = false;
        }


        //lastMousePos = Input.mousePosition;


        //item.GetComponent<Collider>().enabled = false;
    }

    void dropOff()
    {
        pickedup = false;
        itemRotate = false;
        //itemTransform.SetParent(trashCan);

        //Vector3 holderWorldPos = itemTransform.InverseTransformPoint(holder.position);
        //Vector3 holderWorldRot = itemTransform.InverseTransformPoint(holder.eulerAngles);
        itemTransform.localPosition = Vector3.zero;
        itemTransform.localEulerAngles = (Vector3.zero);
        //itemTransform.eulerAngles = holder.eulerAngles;
        ;
        itemTransform.localScale = itemOffset * 0.1f;
        itemRB.useGravity = false;
        itemRB.isKinematic = false;
        itemRB.detectCollisions = false;
        //item.GetComponent<Collider>().enabled = true;
    }

    void onDestroy()
    {
        Destroy(gameObject);
        canAnim.SetTrigger("trashIn");
        //canAnim.ResetTrigger("trashIn");
    }
}