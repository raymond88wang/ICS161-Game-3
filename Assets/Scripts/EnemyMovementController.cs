using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour {

    private Transform player1;
    private Transform player2;

    private NavMeshAgent nav;

    private float dist1;
    private float dist2;
    private bool spotted = false;

    void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").transform;
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;

        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        lookForPlayers();
        if (spotted)
        {
            dist1 = Vector3.Distance(transform.position, player1.position);
            dist2 = Vector3.Distance(transform.position, player2.position);
            //dist2 = Vector3.Distance(transform.position, player2);
            if (dist1 <= dist2)
            {
                nav.SetDestination(player1.position);
            }
            else
            {
                nav.SetDestination(player2.position);
                //nav.SetDestination(player2);

            }
        }
        else
        {
            nav.SetDestination(transform.position);
        }
    }

    private void lookForPlayers()
    {
        RaycastHit hit;

        Vector3 direction1 = player1.position - transform.position;
        Vector3 direction2 = player2.position - transform.position;

        //Vector3 direction2 = player2 - transform.position;
        Debug.DrawRay(transform.position, direction1);
        Debug.DrawRay(transform.position, direction2);

        if (Physics.Raycast(transform.position, direction1, out hit, 20) && (hit.collider.gameObject.CompareTag("Player1") || hit.collider.gameObject.CompareTag("Player2")))
        {
            spotted = true;
        }
        else if (Physics.Raycast(transform.position, direction2, out hit, 20) && (hit.collider.gameObject.CompareTag("Player1") || hit.collider.gameObject.CompareTag("Player2")))
        {
            spotted = true;
        }
        else
        {
            spotted = false;
        }
    }
}
