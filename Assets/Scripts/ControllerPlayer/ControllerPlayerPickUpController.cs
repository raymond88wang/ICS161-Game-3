using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayerPickUpController : MonoBehaviour
{
    private GameObject itemToPickUp;
    public GameObject heldItem = null;
    public GameObject holdSlot;
    private string HeldItemName;
    public Text heldItemText;

    private void Start()
    {
        HeldItemName = "None";
        UpdateHeldItemUI();
    }

    private void Update()
    {
        if (Input.GetButtonDown("X"))
        {
            if (heldItem == null && itemToPickUp != null)
            {
                heldItem = itemToPickUp;
                heldItem.transform.parent = holdSlot.transform;
                heldItem.transform.position = holdSlot.transform.position;
                heldItem.transform.rotation = holdSlot.transform.rotation;
                heldItem.GetComponent<Rigidbody>().isKinematic = true;
                heldItem.GetComponent<SphereCollider>().enabled = false;
                HeldItemName = heldItem.name;
                if (heldItem.name.Equals("Bow"))
                {
                    //itemToPickUp.transform.localPosition = new Vector3( -.5f, - 1.7f, - 3.5f);
                    itemToPickUp.transform.localEulerAngles = new Vector3(-76f, -180f, -90f);
                    itemToPickUp.transform.localPosition = new Vector3(-.5f, 0, 0);
                    GetComponent<ControllerPlayerArrowShootingController>().enabled = true;
                }
                else if (heldItem.name.Equals("Key"))
                {
                    itemToPickUp.transform.localEulerAngles = new Vector3(-121f, -19f, 49.33f);
                    itemToPickUp.transform.localPosition = new Vector3(0.34f, 0.54f, 1.27f);
                }
                Debug.Log("Picked up: " + heldItem.name);
            }

            else if (heldItem != null)
            {
                heldItem.GetComponent<Rigidbody>().isKinematic = false;
                heldItem.GetComponent<SphereCollider>().enabled = true;
                heldItem.transform.parent = null;
                HeldItemName = "None";
                Debug.Log("Dropped: " + heldItem.name);
                if (GetComponent<ControllerPlayerArrowShootingController>() != null)
                {
                    GetComponent<ControllerPlayerArrowShootingController>().enabled = false;
                }
                heldItem = null;
            }
            UpdateHeldItemUI();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (heldItem == null && other.gameObject.CompareTag("item"))
        {
            Debug.Log("Can pick up " + other.gameObject.name);
            itemToPickUp = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        itemToPickUp = null;
    }

    void UpdateHeldItemUI()
    {
        heldItemText.text = "Holding: " + (heldItem == null ? "None" : heldItem.name); // + "\nCan pick up: " + (heldItem == null) + "\nIs holding item: " + (heldItem == null);
    }
    public string getHeldItemName()
    {
        return HeldItemName;
    }
}
