using UnityEngine;

public class ControllerPlayerMovementController : MonoBehaviour {

    public float gravity = 20.0F;
    private CharacterController character;
    public PlayerHealth player;
    //private PlayerHealth player;
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
            moveDirection = new Vector3(Input.GetAxis("LeftJoystickX"), 0, Input.GetAxis("LeftJoystickY"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= player.walkSpeed;
            //Jump
            //if (Input.GetButtonDown("A"))
            if (Input.GetKey(KeyCode.A))
                moveDirection.y = player.jumpSpeed;
            //Sprint
            //if (Input.GetButtonDown("LeftJoystick8"))
            if (Input.GetKey(KeyCode.Joystick1Button8))
            {
                moveDirection *= player.sprintSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        character.Move(moveDirection * Time.deltaTime);
    }
}
