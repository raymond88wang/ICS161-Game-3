using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPickUp : MonoBehaviour
{
    private GameObject itemToPickUp;
    private GameObject holdSlot;
    private GameObject camera;
    private bool canPickUp;
    private bool isHoldingItem;
    private string HeldItemName;
    public Text heldItem;

    // Use this for initialization
    void Start()
    {
        holdSlot = GameObject.FindGameObjectWithTag("hold slot");
        camera = GameObject.FindGameObjectWithTag("camera");
        HeldItemName = "None";
        UpdateHeldItemUI();
        isHoldingItem = false;
        canPickUp = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (HeldItemName.Equals("Bow"))
            GetComponent<ArrowShooting>().enabled = true;
        else
            GetComponent<ArrowShooting>().enabled = false;

        UpdateHeldItemUI();
        if (Input.GetKeyDown("X"))
        {
            if (canPickUp)
            {
                canPickUp = false;
                itemToPickUp.transform.parent = holdSlot.transform;
                itemToPickUp.transform.position = holdSlot.transform.position;
                itemToPickUp.GetComponent<Rigidbody>().isKinematic = true;
                itemToPickUp.GetComponent<SphereCollider>().enabled = false;
                HeldItemName = itemToPickUp.GetComponent<Item>().getName();
                isHoldingItem = true;
                Debug.Log("Picked up an item");
            }
            else if (!canPickUp && isHoldingItem)
            {
                itemToPickUp.GetComponent<Rigidbody>().isKinematic = false;
                itemToPickUp.GetComponent<SphereCollider>().enabled = true;
                itemToPickUp.transform.parent = null;
                itemToPickUp = null;
                isHoldingItem = false;
                HeldItemName = "None";
                Debug.Log("Dropped an item");
            }
            else
                ;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item" && HeldItemName == "None")
        {
            Debug.Log("Can pick up " + other.gameObject.GetComponent<Item>().getName());
            canPickUp = true;
            itemToPickUp = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            Debug.Log("Cannot pick up " + other.gameObject.GetComponent<Item>().getName());
            canPickUp = false;
        }
    }

    void UpdateHeldItemUI()
    {
        //heldItem.text = "Holding: " + HeldItemName + "\nCan pick up: " + canPickUp + "\nIs holding item: " + isHoldingItem;
    }

    public string getHeldItemName()
    {
        return HeldItemName;
    }
}
