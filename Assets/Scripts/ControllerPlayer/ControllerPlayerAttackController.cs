using UnityEngine;

public class ControllerPlayerAttackController : MonoBehaviour {
    private float timer = 0.0f;
    private PlayerHealth player;
    private ControllerPlayerPickUpController pickUp;

    private void Awake()
    {
        player = GetComponent<PlayerHealth>();
        pickUp = GetComponent<ControllerPlayerPickUpController>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if ((Input.GetButtonDown("B") || Input.GetButtonDown("RightBumper")) && timer >= player.attackCooldownTime && pickUp.heldItem != null)
        {
            if (pickUp.heldItem.name.Equals("Bow"))
            {
                pickUp.heldItem.GetComponent<ArrowShootingController>().SpawnArrow();
                timer = 0;
            }
        }
    }
}
