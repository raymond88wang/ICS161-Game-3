using UnityEngine;
using System.Collections;


public class EnemyMeleeAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.

    GameObject player1;                          // Reference to the player GameObject.
    GameObject player2;
    PlayerHealth player1Health;                  // Reference to the player's health.
    PlayerHealth player2Health;
    //EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool anyPlayerInRange;
    bool player1InRange;                         // Whether player is within the trigger collider and can be attacked.
    bool player2InRange;
    float timer;                                // Timer for counting up to the next attack.


    void Awake()
    {
        // Setting up the references.
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1Health = player1.GetComponent<PlayerHealth>();
        player2Health = player2.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            anyPlayerInRange = true;
            player1InRange = true;
        }
        if(other.gameObject.CompareTag("Player2"))
        {
            anyPlayerInRange = true;
            player2InRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            anyPlayerInRange = false;
            player1InRange = false;
        }
        if(other.gameObject.CompareTag("Player2"))
        {
            anyPlayerInRange = false;
            player2InRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && anyPlayerInRange)// && enemyHealth.currentHealth > 0)
        {
            if(player1InRange)
            {
                AttackPlayer1();
            }
            if(player2InRange)
            {
                AttackPlayer2();
            }
        }

    }


    void AttackPlayer1()
    {
        timer = 0f;
        print("Attack1");

        if (player1Health.currentHealth > 0)
        {
            player1Health.TakeDamage(attackDamage);
        }
        
    }

    void AttackPlayer2()
    {
        timer = 0f;
        print("Attack2");

        if (player2Health.currentHealth > 0)
        {
            player2Health.TakeDamage(attackDamage);
        }

    }
}
