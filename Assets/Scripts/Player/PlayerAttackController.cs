using UnityEngine;

public class PlayerAttackController : MonoBehaviour {
    private float timer = 0.0f;
    private PlayerHealth player;
    private PlayerPickUpController pickUp;

    private void Awake()
    {
        player = GetComponent<PlayerHealth>();
        pickUp = GetComponent<PlayerPickUpController>();
    }

    void Update () {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= player.attackCooldownTime && pickUp.heldItem != null)
        {
            if (pickUp.heldItem.name.Equals("Bow"))
            {
                pickUp.heldItem.GetComponent<ArrowShootingController>().SpawnArrow();
                timer = 0;
            }
        }
    }
}
