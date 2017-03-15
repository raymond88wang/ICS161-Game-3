using UnityEngine;
using System.Collections;

public class EnemyAttackController : MonoBehaviour
{
    GameObject player1;                          // Reference to the player GameObject.
    GameObject player2;
    public EnemyHealth enemy;
    private Animator anim;
    //private EnemyHealth enemy;
    private float timer = 0.0f;                     //Timer for counting up to the next attack
    private float distanceToPlayer1 = 0.0f;
    private float distanceToPlayer2 = 0.0f;
    public int damage = 5;
    private TargetLockController targetLock;

    private void Awake()
    {
        // Setting up the references.
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        enemy = GetComponent<EnemyHealth>();
        targetLock = GetComponent<TargetLockController>();

        if (enemy.isRanged != true)
        {
            anim = GetComponentInChildren<Animator>();
        }
    }

    private void Update()
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
        anim.SetTrigger("Swing");

        StartCoroutine(DealDamage(player));
        
        //if (player.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            //player.GetComponent<PlayerHealth>().TakeDamage(damage);
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

    IEnumerator DealDamage(GameObject player)
    {
        yield return new WaitForSeconds(.1f);
        if (player.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
