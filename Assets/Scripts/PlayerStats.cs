using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float startingHealth = 100.0f;
    public float currentHealth = 0.0f;
    public float stamina = 100.0f;
    public float defense = 5.0f;
    public float damage = 0.0f;
    //public Slider healthSlider;                                 
    //public Image damageImage;                                  
    public float flashSpeed = 5f;                               
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);    

    PlayerController playerMovement;                              
    //PlayerShooting playerShooting;                              
    bool isDead;                                                
    bool damaged;                                               

    void Awake()
    {
        playerMovement = GetComponent<PlayerController>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();

        currentHealth = startingHealth;
    }


    void Update()
    {
        if (damaged)
        {
            //damageImage.color = flashColour;
        }
        else
        {
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage(float damageAmount)
    {
        damaged = true;
        currentHealth -= damageAmount;

        //healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        print("Dead");

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;

        Invoke("ReloadLevel", 3);
        //playerShooting.enabled = false;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}