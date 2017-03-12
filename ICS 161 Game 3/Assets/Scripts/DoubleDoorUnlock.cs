using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorUnlock : MonoBehaviour {

    private GameObject P1;
    private GameObject P2;

	// Use this for initialization
	void Start () {
        P1 = GameObject.FindGameObjectWithTag("Player1");
        P2 = GameObject.FindGameObjectWithTag("Player2");
	}
	
	// Update is called once per frame
	void Update () {
        if (P1.GetComponent<Unlock>().playerUsedKeyTrue() && P2.GetComponent<ControllerUnlock>().playerUsedKeyTrue())
        {
            Destroy(gameObject);
            P1.GetComponent<Unlock>().resetPlayerUsedKeyBool();
            P2.GetComponent<ControllerUnlock>().resetPlayerUsedKeyBool();
        }
    }
}
