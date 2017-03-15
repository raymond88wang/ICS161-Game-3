using UnityEngine;

public class DoubleDoorUnlock : MonoBehaviour
{

    private GameObject P1;
    private GameObject P2;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        P1 = GameObject.FindGameObjectWithTag("Player1");
        P2 = GameObject.FindGameObjectWithTag("Player2");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (P1.GetComponent<UnlockController>().playerUsedKeyTrue() && P2.GetComponent<ControllerUnlockController>().playerUsedKeyTrue())
        {
            //Destroy(gameObject);
            anim.SetTrigger("Open");
            P1.GetComponent<UnlockController>().resetPlayerUsedKeyBool();
            P2.GetComponent<ControllerUnlockController>().resetPlayerUsedKeyBool();
        }
    }
}