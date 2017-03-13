using UnityEngine;

public class ArrowCollisionController : MonoBehaviour {

    public int arrowDamage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        print("Hi");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Hit enemy");
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(arrowDamage);
        }
        else if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            print("Hit player: " + collision.gameObject.tag);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(arrowDamage);
        }
        Destroy(gameObject);
    }
}

