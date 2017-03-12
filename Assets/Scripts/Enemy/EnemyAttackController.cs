using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    GameObject player1;                          // Reference to the player GameObject.
    GameObject player2;
    PlayerHealth player1Health;                  // Reference to the player's health.
    PlayerHealth player2Health;
    public EnemyHealth enemy;
    //private EnemyHealth enemy;
    private float timer = 0.0f;                     //Timer for counting up to the next attack
    private float distanceToPlayer1 = 0.0f;
    private float distanceToPlayer2 = 0.0f;
    public int damage = 5;
    private TargetLockController targetLock;

    void Awake()
    {
        // Setting up the references.
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1Health = player1.GetComponent<PlayerHealth>();
        player2Health = player2.GetComponent<PlayerHealth>();
        enemy = GetComponent<EnemyHealth>();
        targetLock = GetComponent<TargetLockController>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= enemy.attackCooldownTime)
        {
            distanceToPlayer1 = Vector3.Distance(transform.position, player1.gameObject.transform.position);
            distanceToPlayer2 = Vector3.Distance(transform.position, player2.gameObject.transform.position);
            if (enemy.isRanged)
            {
                if (targetLock.isNearestTargetInRange(enemy.attackRange))
                {
                    RangeAttackPlayer(targetLock.nearestTarget);
                }
                else
                {
                    GetComponent<EnemyArrowShootingController>().enabled = false;
                }
                //if (distanceToPlayer1 <= distanceToPlayer2 && distanceToPlayer1 <= enemy.attackRange)
                //{
                //    RangeAttackPlayer(player1);
                //}
                //else if (distanceToPlayer2 <= enemy.attackRange)
                //{
                //    RangeAttackPlayer(player2);
                //}
                //else
                //{
                //}
            }
            else
            {
                if (distanceToPlayer1 <= enemy.attackRange && distanceToPlayer2 <= enemy.attackRange)
                {
                    MeleeAttackPlayer(player1);
                    MeleeAttackPlayer(player2);
                }
                else if (distanceToPlayer1 <= enemy.attackRange)
                {
                    MeleeAttackPlayer(player1);
                }
                else if (distanceToPlayer2 <= enemy.attackRange)
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

        if (player.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void RangeAttackPlayer(GameObject player)
    {
        timer = 0f;
        GetComponent<EnemyArrowShootingController>().enabled = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemy.attackRange);
    }
}
