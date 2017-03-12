using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPlatform : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void LowerThePlatform()
    {
        anim.SetTrigger("Lower");
    }
}
