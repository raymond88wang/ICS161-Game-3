using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float lookRange = 20.0f;
    public float attackRange = 5.0f;
    public float attackCooldownTime = 1.0f;
    public bool isRanged = false;

    void Awake()
    {
        currentHealth = startingHealth;
        isRanged = GetComponent<EnemyArrowShootingController>() != null;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject, 0);     
    }
}
