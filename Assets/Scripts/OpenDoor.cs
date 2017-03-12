using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenTheDoor()
    {
        anim.SetTrigger("Open");
    }
}
