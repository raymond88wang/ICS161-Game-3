using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public float walkSpeed = 3.0F;
    public float runSpeed = 6.0F;
    public float jumpSpeed = 4.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController player;

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
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;
            //Jump
            if (Input.GetKey(KeyCode.Space))
                moveDirection.y = jumpSpeed;
            //Sprint
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= runSpeed;
            }
            else
            {
                moveDirection *= walkSpeed;
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;
        player.Move(moveDirection * Time.deltaTime);
    }
}
