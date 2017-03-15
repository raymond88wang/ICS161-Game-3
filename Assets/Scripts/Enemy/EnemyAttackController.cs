using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private Animator anim;
    private EnemyHealth enemy;
    private float timer = 0.0f;                     //Timer for counting up to the next attack
    private TargetLockController targetLock;

    private void Awake()
    {
        // Setting up the references.
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
            if (targetLock.isNearestTargetInRange(enemy.attackRange))
            {
                if (enemy.isRanged)
                {
                    RangeAttackPlayer(targetLock.nearestTarget);
                }
                else
                {
                    MeleeAttackPlayer(targetLock.nearestTarget);
                }
            }
        }
    }

    private void MeleeAttackPlayer(GameObject player)
    {
        anim.SetTrigger("Swing");
        timer = 0f;
    }

    private void RangeAttackPlayer(GameObject player)
    {
        GetComponentInChildren<EnemyArrowShootingController>().SpawnArrow();
        timer = 0f;
    }
}
