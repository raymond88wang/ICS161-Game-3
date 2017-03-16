using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    private Animator anim;
    private AudioSource audioPlayer;
    public AudioClip openDoorSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    public void OpenTheDoor()
    {
        audioPlayer.PlayOneShot(openDoorSound, 2.0f);
        anim.SetTrigger("Open");
    }
}
