using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPlatform : MonoBehaviour {

    private Animator anim;
    private AudioSource audioPlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    public void LowerThePlatform()
    {
        audioPlayer.Play();
        anim.SetTrigger("Lower");
    }
}
