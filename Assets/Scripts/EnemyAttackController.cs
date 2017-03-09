using UnityEngine;


public class EnemyAttackController : MonoBehaviour
{
    GameObject player1;                          // Reference to the player GameObject.
    GameObject player2;
    PlayerStats player1Health;                  // Reference to the player's health.
    PlayerStats player2Health;
    private EnemyStats enemy;
    public GameObject bullets, bulletsSpawnPoint;
    public float bulletForce;
    private float timer = 0.0f;                     //Timer for counting up to the next attack
    private float distanceToPlayer1 = 0.0f;
    private float distanceToPlayer2 = 0.0f;
    public float range = 2.5f;

    void Awake()
    {
        // Setting up the references.
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1Health = player1.GetComponent<PlayerStats>();
        player2Health = player2.GetComponent<PlayerStats>();
        enemy = GetComponent<EnemyStats>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= enemy.attackCooldownTime)// && enemyHealth.currentHealth > 0)
        {
            distanceToPlayer1 = Vector3.Distance(transform.position, player1.gameObject.transform.position);
            distanceToPlayer2 = Vector3.Distance(transform.position, player2.gameObject.transform.position);
            if(enemy.isRanged)
            {
                if (distanceToPlayer1 <= distanceToPlayer2 && distanceToPlayer1 <= enemy.range)
                {
                    RangeAttackPlayer(player1);
                }
                else if (distanceToPlayer2 <= enemy.range)
                {
                    RangeAttackPlayer(player2);
                }
            }
            else
            {
                if(distanceToPlayer1 <= enemy.range && distanceToPlayer2 <= enemy.range)
                {
                    MeleeAttackPlayer(player1);
                    MeleeAttackPlayer(player2);
                }
                else if (distanceToPlayer1 <= enemy.range)
                {
                    MeleeAttackPlayer(player1);
                }
                else if (distanceToPlayer2 <= enemy.range)
                {
                    MeleeAttackPlayer(player2);
                }
            }
        }
    }

    private void MeleeAttackPlayer(GameObject player)
    {
        timer = 0f;
        print("Attacked player: " + player.tag);

        if (player.GetComponent<PlayerStats>().currentHealth > 0)
        {
            player.GetComponent<PlayerStats>().TakeDamage(enemy.damage);
        }
    }

    private void RangeAttackPlayer(GameObject player)
    {
        timer = 0f;
        print("Attacked player: " + player.tag);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(transform.position, enemy.range);
        Gizmos.DrawWireSphere(transform.position, range);
    }


    //void AttackPlayer1()
    //{
    //    timer = 0f;
    //    print("Attack1");

    //    if (player1Health.currentHealth > 0)
    //    {
    //        player1Health.TakeDamage(attackDamage);
    //    }

    //}

    //void AttackPlayer2()
    //{
    //    timer = 0f;
    //    print("Attack2");

    //    if (player2Health.currentHealth > 0)
    //    {
    //        player2Health.TakeDamage(attackDamage);
    //    }

    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player1"))
    //    {
    //        anyPlayerInRange = true;
    //        player1InRange = true;
    //    }
    //    if(other.gameObject.CompareTag("Player2"))
    //    {
    //        anyPlayerInRange = true;
    //        player2InRange = true;
    //    }
    //}


    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player1"))
    //    {
    //        anyPlayerInRange = false;
    //        player1InRange = false;
    //    }
    //    if(other.gameObject.CompareTag("Player2"))
    //    {
    //        anyPlayerInRange = false;
    //        player2InRange = false;
    //    }
    //}
}
