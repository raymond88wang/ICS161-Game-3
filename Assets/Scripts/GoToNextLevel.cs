﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    private bool player1ready = false;
    private bool player2ready = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            player1ready = true;
            if (player2ready)
            {
                ChangeLevel();
            }
        }
        if (other.gameObject.name == "Player2")
        {
            player2ready = true;
            if (player1ready)
            {
                ChangeLevel();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            player1ready = false;
        }
        if (other.gameObject.name == "Player2")
        {
            player2ready = false;
        }
    }

    private void StartMainLevel()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Main Game"));
    }
    
    private void GoToMainMenu()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Main Menu"));
    }

    private void ChangeLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartMainLevel();
        }
        else
        {
            GoToMainMenu();
        }
    }
}
