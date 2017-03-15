using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    Animator anim;
    public AudioClip doorOpenSound;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenTheDoor()
    {
        GetComponent<AudioSource>().PlayOneShot(doorOpenSound, 0.5f);
        anim.SetTrigger("Open");
    }

    public void CloseTheDoor()
    {
        GetComponent<AudioSource>().PlayOneShot(doorOpenSound, 0.5f);
        anim.SetTrigger("Close");
    }
}
