using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    Animator anim;
    private AudioSource slidingDoor;

    void Start()
    {
        anim = GetComponent<Animator>();
        slidingDoor = GetComponent<AudioSource>();
    }

    public void OpenTheDoor()
    {
        if(slidingDoor != null)
        {
            slidingDoor.Play();
        }
        anim.SetTrigger("Open");
    }
}
