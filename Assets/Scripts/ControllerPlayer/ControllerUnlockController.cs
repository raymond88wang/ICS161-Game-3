using UnityEngine;

public class ControllerUnlockController : MonoBehaviour
{

    private bool canUnlock;
    private bool playerUsedKey;
    private GameObject Lock;

    // Use this for initialization
    void Start()
    {
        canUnlock = false;
        playerUsedKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUnlock && Input.GetButtonDown("B"))
        {
            Debug.Log(Lock.transform.parent.parent);
            if (Lock.transform.parent.parent.parent != null && Lock.transform.parent.parent.parent.CompareTag("double doors"))
            {
                playerUsedKey = true;
                Debug.Log("Player two used key: " + playerUsedKey);
                Debug.Log("Player two used key on double door.");
            }
            else if (Lock.transform.parent.parent.CompareTag("platformA"))
            {
                Debug.Log("Player 1 can pull down platform Y.");
                GameObject.FindGameObjectWithTag("platformY").GetComponent<Animator>().SetTrigger("Lower");
            }
            else if (Lock.transform.parent.parent.CompareTag("platformX"))
            {
                Debug.Log("Player 1 can pull down platform B.");
                GameObject.FindGameObjectWithTag("platformB").GetComponent<Animator>().SetTrigger("Lower");
            }
            else if (Lock.transform.parent.parent.CompareTag("platformB"))
            {
                Debug.Log("Player 1 can pull down platform Z.");
                GameObject.FindGameObjectWithTag("platformZ").GetComponent<Animator>().SetTrigger("Lower");
            }
            else if (Lock.transform.parent.parent.CompareTag("platformY"))
            {
                Debug.Log("Player 1 can pull down platform C.");
                GameObject.FindGameObjectWithTag("platformC").GetComponent<Animator>().SetTrigger("Lower");
            }
            else
            {
                //Destroy(Lock.transform.parent.gameObject);
                //Destroy(Lock);
                Lock.transform.parent.GetComponent<Animator>().SetTrigger("Open");
            }
            canUnlock = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lock" && GetComponent<ControllerPlayerPickUpController>().getHeldItemName().Equals("Key"))
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