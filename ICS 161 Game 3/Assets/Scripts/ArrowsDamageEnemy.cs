using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsDamageEnemy : MonoBehaviour {

    public int arrowDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(arrowDamage);
            //Destroy(gameObject, 0); // can fix later
        }

    }
}

