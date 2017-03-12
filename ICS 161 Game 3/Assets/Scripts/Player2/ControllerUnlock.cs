﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUnlock : MonoBehaviour
{

    private bool canUnlock;
    private bool playerUsedKey;
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
            Debug.Log(Lock.transform.parent.parent);
            if (Lock.transform.parent.parent.parent != null && Lock.transform.parent.parent.parent.CompareTag("double doors"))
            { 
                playerUsedKey = true;
                Debug.Log("Player two used key: " + playerUsedKey);
                Debug.Log("Player two used key on double door.");
            }
            else
            {
                Lock.transform.parent.GetComponent<Animator>().SetTrigger("Open");
            }
            canUnlock = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lock" && GetComponent<ControllerPickUp>().getHeldItemName() == "Key")
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

    public bool playerUsedKeyTrue()
    {
        return playerUsedKey;
    }

    public void resetPlayerUsedKeyBool()
    {
        playerUsedKey = false;
    }

}