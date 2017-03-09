using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public CharacterController c;

    private Vector3 moveDirection = Vector3.zero;

    

    void Start()
    {
        c = GetComponent<CharacterController>();
    }

    void Update()
    {
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





   





}