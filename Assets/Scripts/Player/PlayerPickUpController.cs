using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpController : MonoBehaviour {
    private GameObject itemToPickUp;
    public GameObject heldItem = null;
    public GameObject holdSlot;
    private string HeldItemName;
    public Text heldItemText;
    private PlayerHealth player;

    private void Start ()
    {
        player = GetComponent<PlayerHealth>();
        HeldItemName = "None";
        UpdateHeldItemUI();
    }

    private void Update ()
    {
        if (Input.GetKey(KeyCode.N))
        {
            print(heldItem.transform.localEulerAngles);
            print(heldItem.transform.localPosition);
        }
        if (Input.GetKeyDown("e"))
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
                    heldItem.gameObject.GetComponent<ArrowShootingController>().camDirection = player.GetComponentInChildren<Camera>().transform;
                    heldItem.transform.localEulerAngles = new Vector3(-76f, -180f, -90f);
                    heldItem.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
                }
                else if (heldItem.name.Equals("Key"))
                {
                    heldItem.transform.localEulerAngles = new Vector3(-3.5f, -90f, 128f);
                    heldItem.transform.localPosition = new Vector3(-0.2f, 0.6f, 1.7f);
                }
                
                Debug.Log("Picked up: " + heldItem.name);
            }

            else if (heldItem != null)
            {
                heldItem.GetComponent<Rigidbody>().isKinematic = false;
                heldItem.GetComponent<SphereCollider>().enabled = true;
                heldItem.transform.parent = null;
                HeldItemName = "None";
                if(heldItem.GetComponentInChildren<SwordCollisionController>() != null)
                {
                    heldItem.GetComponentInChildren<SwordCollisionController>().isOnGround = true;
                }
                Debug.Log("Dropped: " + heldItem.name);
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
