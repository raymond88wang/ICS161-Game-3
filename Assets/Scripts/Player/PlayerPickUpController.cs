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
                    player.attackCooldownTime = 0.5f;
                    player.defense = 1.0f;
                    heldItem.gameObject.GetComponent<ArrowShootingController>().camDirection = player.GetComponentInChildren<Camera>().transform;
                    heldItem.transform.localEulerAngles = new Vector3(-85f, -150f, -130f);
                    heldItem.transform.localPosition = holdSlot.transform.localPosition + new Vector3(-0.8f, 1.4f, -0.5f);
                }
                else if (heldItem.name.Equals("Key"))
                {
                    heldItem.transform.localEulerAngles = holdSlot.transform.localEulerAngles;
                    heldItem.transform.Rotate(new Vector3(0, 60, -97));
                    heldItem.transform.localPosition = holdSlot.transform.localPosition + new Vector3(-1.4f, 0.0f, 1.5f);
                }
                else if (heldItem.name.Equals("Sword"))
                {
                    player.attackCooldownTime = 0.25f;
                    player.defense = 10.0f;
                    player.startingStamina = 200.0f;
                    heldItem.transform.localEulerAngles = holdSlot.transform.localEulerAngles;
                    heldItem.transform.Rotate(Vector3.up * -130);
                    heldItem.transform.localPosition = holdSlot.transform.localPosition + new Vector3(-0.5f, 0.8f, -0.4f);
                    heldItem.GetComponentInChildren<CapsuleCollider>().enabled = true;
                    heldItem.GetComponentInChildren<SwordCollisionController>().isOnGround = false;
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
