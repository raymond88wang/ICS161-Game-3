using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100.0f;                            
    public float currentHealth;
    public float startingStamina = 100.0f;
    public float currentStamina;
    public float staminaDepletionScale = 80.0f;
    public float staminaReplenishScale = 30.0f;
    //public Slider healthSlider;                                 
    //public Image damageImage;         
    public Image damageImage;
    public Image currentHealthBar;
    public Image currentStaminaBar;
    public float walkSpeed = 6.0f;
    public float sprintSpeed = 2.5f;
    public float jumpSpeed = 8.0f;
    public float flashSpeed = 5f;                               
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float defense = 1.0f;
    public float attackCooldownTime = 1.0f;
    private float restartTimer = 0;
    private float timer = 0;
    public AudioClip heartbeat;
    public AudioClip hit;
    public AudioClip dead;

    //PlayerController playerMovement;                              
    //PlayerShooting playerShooting;                              
    bool isDead;                                                
    bool damaged;
    public Text deathMessage;
    public Text restartMessage;

    void Awake()
    {
        //playerMovement = GetComponent<PlayerController>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();
        //healthSlider.maxValue = startingHealth;
        //healthSlider.value = startingHealth;


        currentHealth = startingHealth;
        currentStamina = startingStamina;
        deathMessage.text = "";
        restartMessage.text = "";
        updateHealth();
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if(currentHealth < 25 && timer >= 9)
        {
            GameObject.FindGameObjectWithTag("Game Music").GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(heartbeat, 0.5f);
            timer = 0;
        }

        if (isDead)
        {
            restartMessage.text = "Restart: " + (int) (restartTimer + 1);
            restartTimer -= Time.deltaTime;
        }
    }


    public void TakeDamage(float damageAmount)
    {
        GetComponent<AudioSource>().PlayOneShot(hit, 0.5f);

        damaged = true;
        currentHealth -= (damageAmount / defense);

        updateHealth();

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
        GameObject.FindGameObjectWithTag("Boss Battle Music").GetComponent<AudioSource>().Stop();
        GameObject.FindGameObjectWithTag("Game Music").GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(dead, 0.5f);
        deathMessage.text = gameObject.name.ToString() + "Died";
        if (GetComponent<PlayerMovementController>() != null)
        {
            GetComponent<PlayerMovementController>().enabled = false;
        }
        if (GetComponent<PlayerAttackController>() != null)
        {
            GetComponent<PlayerAttackController>().enabled = false;
        }
        if (GetComponent<ControllerPlayerMovementController>() != null)
        {
            GetComponent<ControllerPlayerMovementController>().enabled = false;
        }
        if (GetComponent<ArrowShootingController>() != null)
        {
            GetComponent<ArrowShootingController>().enabled = false;
        }
        restartTimer = 3;
        Invoke("ReloadLevel", restartTimer);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathMessage.text = "";
        restartMessage.text = "";
    }

    void updateHealth()
    {
        float ratio = (float)currentHealth / startingHealth;
        if (ratio < 0)
        {
            ratio = 0;
        }
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void updateStamina()
    {
        float ratio = (float)currentStamina / startingStamina;
        if (ratio < 0)
        {
            ratio = 0;
        }
        currentStaminaBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}