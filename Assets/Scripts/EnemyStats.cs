using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    [Header("Attributes")]
    public float startingHealth = 100.0f;           // The amount of health the enemy starts the game with.
    public float currentHealth = 0.0f;                 // The current health the enemy has.
    public float defense = 5.0f;
    public float damage = 5.0f;
    public float range = 2.5f;
    public float attackCooldownTime = 1.0f;
    public bool isRanged = false;

    void Awake()
    {
        currentHealth = startingHealth;
        isRanged = this.gameObject.GetComponent<ArrowShootingController>() != null ? true : false;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

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
