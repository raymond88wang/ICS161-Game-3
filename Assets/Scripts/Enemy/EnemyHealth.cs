using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float lookRange = 20.0f;
    public float attackRange = 5.0f;
    public float attackCooldownTime = 1.0f;
    public bool isRanged = false;
    public bool isBoss = false;
    public Image currentBossHealthBar = null;
    public GameObject bossHealthBar = null;
    public GameObject door = null;
    public AudioClip bossDead;

    void Awake()
    {
        currentHealth = startingHealth;
        isRanged = GetComponent<EnemyArrowShootingController>() != null;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (isBoss)
        {
            UpdateHealthBar();
        }
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        if (door != null)
        {
            door.GetComponent<OpenDoor2>().EnemyDied();
        }

        if (isBoss)
        {
            GameObject.FindGameObjectWithTag("Boss Battle Music").GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("Boss Battle Music").GetComponent<AudioSource>().PlayOneShot(bossDead, 0.5f);
            bossHealthBar.SetActive(false);
        }
        Destroy(gameObject, 0);     
    }

    void UpdateHealthBar()
    {
        float ratio = (float)currentHealth / startingHealth;
        if (ratio < 0)
        {
            ratio = 0;
        }
        currentBossHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}
