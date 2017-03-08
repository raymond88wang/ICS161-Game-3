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
    private string HeldItemName;
    private GameObject itemToPickUp;

    void Start()
    {
        c = GetComponent<CharacterController>();
        HeldItemName = "None";
        UpdateHeldItemUI();
    }

    void Update()
    {
        if(canPickUp && Input.GetKeyDown("e"))
        {
            HeldItemName = itemToPickUp.GetComponent<Item>().getName();
            UpdateHeldItemUI();
            Destroy(itemToPickUp);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            Debug.Log("Can pick up.");
            canPickUp = true;
            itemToPickUp = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            Debug.Log("Cannot pick up.");
            canPickUp = false;
            itemToPickUp = null;
        }
    }

    void UpdateHeldItemUI()
    {
        Debug.Log("currently held item: " + HeldItemName);
    }





}