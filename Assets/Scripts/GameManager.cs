using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject readyPanel;
    public Text player1ReadyText;
    public Text player2ReadyText;

    private bool player1Ready;
    private bool player2Ready;
    private bool player2CanReady;
    private bool canChangeReady;

    private void Start()
    {
        player1Ready = false;
        player2Ready = false;
        player2CanReady = false;
        canChangeReady = true;
        
    }


    void Update()
    {
        if (readyPanel.activeSelf)
        {
            if (Input.GetJoystickNames() == null || Input.GetJoystickNames()[0] == "")
            {
                player2CanReady = false;
                player2Ready = false;
            }
            else
            {
                player2CanReady = true;
            }

            if (player2CanReady && Input.GetButtonDown("A") && canChangeReady)
            {
                player2Ready = !player2Ready;
            }
      
            if (Input.GetButtonDown("Jump") && canChangeReady)
            {
                player1Ready = !player1Ready;
            }

            if (player1Ready)
            {
                player1ReadyText.text = "Ready!";
            }
            else
            {
                player1ReadyText.text = "Hit Space When Ready";
            }

            if (player2Ready && player2CanReady)
            {
                player2ReadyText.text = "Ready!";
            }
            else if (!player2CanReady)
            {
                player2ReadyText.text = "Please plug in a controller";
            }
            else
            {
                player2ReadyText.text = "Hit A When Ready";
            }

            if(player1Ready && player2Ready)
            {
                canChangeReady = false;
                StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Level 1 - Tutorial"));
            }

        }
        else
        {
            player1Ready = false;
            player2Ready = false;
            player2CanReady = false;
        }
        
    }
}
