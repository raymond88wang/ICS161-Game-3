using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour {

    private bool canUnlock;
    private bool playerUsedKey;
    private GameObject Lock;

	// Use this for initialization
	void Start () {
        canUnlock = false;
        playerUsedKey = false;
	}

    // Update is called once per frame
    void Update() {
        if (canUnlock && Input.GetMouseButtonDown(0))
        {
            Debug.Log(Lock.transform.parent.parent);
            if (Lock.transform.parent.parent != null)
            {
                playerUsedKey = true;
                Debug.Log("Player two used key: " + playerUsedKey);
                Debug.Log("Player two used key on double door.");
            }
            else
            {
                Destroy(Lock.transform.parent.gameObject);
                Destroy(Lock);
            }
            canUnlock = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lock" && GetComponent<PickUp>().getHeldItemName() == "Key")
        {
            canUnlock = true;
            Lock = other.gameObject;
            Debug.Log("Can unlock: " + canUnlock);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "lock")
        {
            canUnlock = false;
            Lock = null;
            Debug.Log("Can unlock: " + canUnlock);
        }
    }

    public bool playerUsedKeyTrue()
    {
        return playerUsedKey;
    }

    public void resetPlayerUsedKeyBool()
    {
        playerUsedKey = false;
    }

}
