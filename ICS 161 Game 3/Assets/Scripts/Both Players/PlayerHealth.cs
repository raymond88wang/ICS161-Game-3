﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            
    public int currentHealth;                                   
    //public Slider healthSlider;                                 
    public Image damageImage;
    public Image currentHealthBar;                               
    public float flashSpeed = 5f;                               
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);    

    //PlayerController playerMovement;                              
    //PlayerShooting playerShooting;                              
    bool isDead;                                                
    bool damaged;
    public Text deathMessage;                                            

    void Awake()
    {
        //playerMovement = GetComponent<PlayerController>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();
        //healthSlider.maxValue = startingHealth;
        //healthSlider.value = startingHealth;


        currentHealth = startingHealth;
        deathMessage.text = "";
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
        // Turn off the movement and shooting scripts.
        //playerMovement.enabled = false;

        Invoke("ReloadLevel", 3);
        //playerShooting.enabled = false;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathMessage.text = "";
    }

    void updateHealth()
    {
        float ratio = (float) currentHealth / startingHealth;
        print(ratio);
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

    }
}