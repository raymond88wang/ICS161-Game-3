using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayerPickUpController : MonoBehaviour
{
    private GameObject itemToPickUp;
    public GameObject heldItem = null;
    public GameObject holdSlot;
    public Text heldItemText;

    private void Start()
    {
        UpdateHeldItemUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (heldItem == null)
            {
                heldItem = itemToPickUp;
                heldItem.transform.parent = holdSlot.transform;
                heldItem.transform.position = holdSlot.transform.position;
                heldItem.transform.rotation = holdSlot.transform.rotation;
                heldItem.GetComponent<Rigidbody>().isKinematic = true;
                heldItem.GetComponent<SphereCollider>().enabled = false;
                if (heldItem.name.Equals("Bow"))
                {
                    //itemToPickUp.transform.localPosition = new Vector3( -.5f, - 1.7f, - 3.5f);
                    itemToPickUp.transform.localEulerAngles = new Vector3(-76f, -180f, -90f);
                    itemToPickUp.transform.localPosition = new Vector3(-.5f, 0, 0);
                    GetComponent<PlayerArrowShootingController>().enabled = true;
                }
                Debug.Log("Picked up: " + heldItem.name);
            }
            else
            {
                heldItem.GetComponent<Rigidbody>().isKinematic = false;
                heldItem.GetComponent<SphereCollider>().enabled = true;
                heldItem.transform.parent = null;
                Debug.Log("Dropped: " + heldItem.name);
                GetComponent<PlayerArrowShootingController>().enabled = false;
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

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "item")
    //    {
    //        Debug.Log("Cannot pick up " + other.gameObject.GetComponent<Item>().getName());
    //        canPickUp = false;
    //    }
    //}

    void UpdateHeldItemUI()
    {
        heldItemText.text = "Holding: " + (heldItem == null ? "None" : heldItem.name) + "\nCan pick up: " + (heldItem == null) + "\nIs holding item: " + (heldItem == null);
    }

    //public string getHeldItemName()
    //{
    //    return HeldItemName;
    //}
}
