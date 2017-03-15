using UnityEngine;

public class ArrowCollisionController : MonoBehaviour {

    public int arrowDamage = 10;
    private bool hasDealtDamage = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasDealtDamage)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                print("Hit enemy");
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(arrowDamage);
                hasDealtDamage = true;
            }
            else if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
            {
                print("Hit player: " + collision.gameObject.tag);
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(arrowDamage / 2);
                hasDealtDamage = true;
            }
        }
        Destroy(gameObject);
    }
}

