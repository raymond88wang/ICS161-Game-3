using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            
    public int currentHealth;
    //public Slider healthSlider;                                 
    //public Image damageImage;         
    public Image damageImage;
    public Image currentHealthBar;
    public float flashSpeed = 5f;                               
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float walkSpeed = 6.0f;
    public float sprintSpeed = 2.5f;
    public float jumpSpeed = 8.0f;
    public float stamina = 100.0f;
    public float attackCooldownTime = 1.0f;
    private float restartTimer = 0;

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
        deathMessage.text = "";
        restartMessage.text = "";
        updateHealth();
    }


    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if(isDead)
        {
            restartMessage.text = "Restart: " + (int) (restartTimer + 1);
            restartTimer -= Time.deltaTime;
        }
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

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

        deathMessage.text = gameObject.name.ToString() + "Died";
        if (GetComponent<PlayerMovementController>() != null)
        {
            GetComponent<PlayerMovementController>().enabled = false;
        }
        if (GetComponent<PlayerArrowShootingController>() != null)
        {
            GetComponent<PlayerArrowShootingController>().enabled = false;
        }
        if (GetComponent<ControllerPlayerMovementController>() != null)
        {
            GetComponent<ControllerPlayerMovementController>().enabled = false;
        }
        if (GetComponent<ControllerPlayerArrowShootingController>() != null)
        {
            GetComponent<ControllerPlayerArrowShootingController>().enabled = false;
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
}