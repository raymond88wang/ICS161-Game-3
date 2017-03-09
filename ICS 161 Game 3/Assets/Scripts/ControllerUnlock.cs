﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUnlock : MonoBehaviour
{

    private bool canUnlock;
    private GameObject Lock;

    // Use this for initialization
    void Start()
    {
        canUnlock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUnlock && Input.GetButtonDown("B"))
        {
            Destroy(Lock.transform.parent.gameObject);
            Destroy(Lock);
            canUnlock = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lock" && GetComponent<PickUp>().getHeldItemName() == "Key")
        {
            canUnlock = true;
            Lock = other.gameObject;
            Debug.Log("Can unlock: " + canUnlock);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "lock")
        {
            canUnlock = false;
            Lock = null;
            Debug.Log("Can unlock: " + canUnlock);
        }
    }

}