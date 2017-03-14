using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float gravity = 20.0F;
    private CharacterController character;
    private PlayerHealth player;
    public Vector3 moveDirection = Vector3.zero;

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
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = player.jumpSpeed;
            }
            //Sprint
            if (Input.GetKey(KeyCode.LeftShift) && player.currentStamina > 0)
            {
                player.currentStamina -= player.staminaDepletionScale * Time.deltaTime;
                moveDirection.x *= player.sprintSpeed;
                moveDirection.z *= player.sprintSpeed;
                player.updateStamina();
            }
            if (player.currentStamina < player.startingStamina)
            {
                player.currentStamina += player.staminaReplenishScale * Time.deltaTime;
                if (player.currentStamina > player.startingStamina)
                {
                    player.currentStamina = player.startingStamina;
                }
                player.updateStamina();
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        character.Move(moveDirection * Time.deltaTime);
    }





   





}