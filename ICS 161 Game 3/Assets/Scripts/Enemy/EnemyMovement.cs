using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    private Transform player1;
    private Transform player2;
    public EnemyHealth enemy;
    //private EnemyHealth enemy;
    private NavMeshAgent nav = null;

    private float dist1 = 0.0f;
    private float dist2 = 0.0f;
    private float bodyRotateSpeed = 5.0f;
    private bool spotted = false;

    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").transform;
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        enemy = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        lookForPlayers();
        if (spotted)
        {
            dist1 = Vector3.Distance(transform.position, player1.position);
            dist2 = Vector3.Distance(transform.position, player2.position);
            if (!enemy.isRanged)
            {
                if (dist1 <= dist2)
                {
                    nav.SetDestination(player1.position);
                }
                else
                {
                    nav.SetDestination(player2.position);
                }
            }
            else
            {
                if (dist1 <= dist2)
                {
                    RotateTowards(player1);
                }
                else
                {
                    RotateTowards(player2);
                }
            }
        }
        else
        {
            if (nav != null)
            {
                nav.SetDestination(transform.position);
            }
        }
    }

    private void lookForPlayers()
    {
        RaycastHit hit;

        Vector3 direction1 = player1.position - transform.position;
        Vector3 direction2 = player2.position - transform.position;

        Debug.DrawRay(transform.position, direction1);
        Debug.DrawRay(transform.position, direction2);

        if (Physics.Raycast(transform.position, direction1, out hit, enemy.lookRange) && 
            (hit.collider.gameObject.CompareTag("Player1") || hit.collider.gameObject.CompareTag("Player2")))
        {
            spotted = true;
        }
        else if (Physics.Raycast(transform.position, direction2, out hit, enemy.lookRange) && (hit.collider.gameObject.CompareTag("Player1") || hit.collider.gameObject.CompareTag("Player2")))
        {
            spotted = true;
        }
        else
        {
            spotted = false;
        }
    }

    private void RotateTowards(Transform target)
    {
        Vector3 relativePosition = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(relativePosition);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * bodyRotateSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemy.lookRange);
    }
}
