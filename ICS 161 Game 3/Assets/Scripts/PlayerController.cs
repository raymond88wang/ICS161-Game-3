using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public CharacterController c;
    public Text heldItem;

    private Vector3 moveDirection = Vector3.zero;
    private bool canPickUp;
    private bool isHoldingItem;
    private string HeldItemName;
    private GameObject itemToPickUp;
    private GameObject holdSlot;
    private GameObject camera;

    void Start()
    {
        c = GetComponent<CharacterController>();
        holdSlot = GameObject.FindGameObjectWithTag("hold slot");
        camera = GameObject.FindGameObjectWithTag("camera");
        HeldItemName = "None";
        UpdateHeldItemUI();
        isHoldingItem = false;
        canPickUp = false;
    }

    void Update()
    {
        UpdateHeldItemUI();

        if (Input.GetKeyDown("e"))
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

            if (c.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        c.Move(moveDirection * Time.deltaTime);
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item" && HeldItemName == "None")
        {
            Debug.Log("Can pick up " + other.gameObject.tag);
            canPickUp = true;
            itemToPickUp = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            Debug.Log("Cannot pick up" + other.gameObject.tag);
            canPickUp = false;
        }
    }

    void UpdateHeldItemUI()
    {
        heldItem.text = "Holding: " + HeldItemName + "\nCan pick up: " + canPickUp + "\nIs holding item: " + isHoldingItem;
    }





}