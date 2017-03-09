using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    private CharacterController player;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("B"))
        {
            print("Fire"); // would have to push everytime
        }

        if (player.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("LeftJoystickX"), 0, Input.GetAxis("LeftJoystickY") * -1);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButtonDown("A"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        player.Move(moveDirection * Time.deltaTime);
       
    }
}
