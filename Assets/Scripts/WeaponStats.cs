using UnityEngine;

public class WeaponStats : MonoBehaviour {
    public float range = 0.0F;
    public float damage = 10.0F;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
