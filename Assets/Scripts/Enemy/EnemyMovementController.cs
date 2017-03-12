using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    private TargetLockController targetLock;
    public EnemyHealth enemy;
    //private EnemyHealth enemy;
    private NavMeshAgent nav;
    private float bodyRotateSpeed = 5.0f;

    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        nav = GetComponent<NavMeshAgent>();
        enemy = GetComponent<EnemyHealth>();
        targetLock = GetComponent<TargetLockController>();
    }

    private void Update()
    {
        if (targetLock.isTargetSpotted(player1, enemy.lookRange) || targetLock.isTargetSpotted(player2, enemy.lookRange))
        {
            if (enemy.isRanged)
            {
                RotateTowards(targetLock.nearestTarget);
            }
            else
            {
                MoveTowards(targetLock.nearestTarget);
            }
        }
        else
        {
            if (nav != null)
            {
                MoveTowards(this.gameObject);
            }
        }
    }

    private void RotateTowards(GameObject target)
    {
        Vector3 relativePosition = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(relativePosition);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * bodyRotateSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void MoveTowards(GameObject target)
    {
        nav.SetDestination(target.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemy.lookRange);
    }
}
