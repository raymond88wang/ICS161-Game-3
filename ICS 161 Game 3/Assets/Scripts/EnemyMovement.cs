using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    private Transform player1;
    private Transform player2;

    private NavMeshAgent nav;

    private float dist1;
    private float dist2;

    void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").transform;
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;

        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        dist1 = Vector3.Distance(transform.position, player1.position);
        dist2 = Vector3.Distance(transform.position, player2.position);
        print("dist1: " + dist1);
        print("dist2: " + dist2);


        if ( dist1 <= dist2)
        {
            nav.SetDestination(player1.position);
        }
        else
        {
            nav.SetDestination(player2.position);
        }
    }
}
