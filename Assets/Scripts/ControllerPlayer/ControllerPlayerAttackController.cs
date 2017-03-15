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
        if (Input.GetButtonDown("B") && timer >= player.attackCooldownTime && pickUp.heldItem != null)
        {
            if (pickUp.heldItem.name.Equals("Bow"))
            {
                pickUp.heldItem.GetComponent<ArrowShootingController>().SpawnArrow();
                timer = 0;
            }
            else if (pickUp.heldItem.name.Equals("Sword"))
            {
                GetComponentInChildren<Animator>().SetTrigger("Swing");
                timer = 0;
            }
        }
    }
}
