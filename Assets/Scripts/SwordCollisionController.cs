using UnityEngine;

public class SwordCollisionController : MonoBehaviour {
    public float damage = 5.0f;
    public bool isOnGround = true;
    public bool isPlayerHoldingSword = false;

    private void Start()
    {
        if(GetComponentInParent<EnemyHealth>() == null)
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<EnemyHealth>() != null && collider.gameObject.GetComponent<EnemyHealth>().currentHealth > 0)
        {
            if (collider.gameObject.name != transform.parent.transform.parent.name)
            {
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SwingSword"))
                {
                    collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                    damage = 0.0f;
                }
            }
        }
        if(collider.gameObject.GetComponent<PlayerHealth>() != null && collider.gameObject.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            if(!isOnGround && !isPlayerHoldingSword)
            {
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SwingSword"))
                {
                    collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                    damage = 0.0f;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        damage = 5f;
    }
}
