using UnityEngine;

public class ArrowCollisionController : MonoBehaviour {

    public float arrowDamage = 10.0f;
    private bool hasAppliedDamage = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasAppliedDamage)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                print("Hit enemy");
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(arrowDamage);
                hasAppliedDamage = true;
            }
            else if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
            {
                print("Hit player: " + collision.gameObject.tag);
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(arrowDamage / 2);
                hasAppliedDamage = true;
            }
        }
        Destroy(gameObject);
    }
}

