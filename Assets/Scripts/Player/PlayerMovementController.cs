using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float gravity = 20.0F;
    private CharacterController character;
    private PlayerHealth player;
    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        player = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (character.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= player.walkSpeed;
            //Jump
            if (Input.GetKey(KeyCode.Space))
                moveDirection.y = player.jumpSpeed;
            //Sprint
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= player.sprintSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        character.Move(moveDirection * Time.deltaTime);
    }





   





}