using UnityEngine;

public class BossFightStart : MonoBehaviour {

    public GameObject bossHealthBar;
    private AudioSource bossBattle;
    private GameObject boss;
    public OpenDoor bossDoor;

    private void Awake()
    {
        bossBattle = GetComponentInChildren<AudioSource>();
        boss = GameObject.Find("Boss");
        bossHealthBar.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (boss != null)
        {
            GameObject.FindGameObjectWithTag("Game Music").GetComponent<AudioSource>().Stop();
            if (!bossBattle.isPlaying && boss != null)
            {
                bossBattle.Play();
                bossDoor.CloseTheDoor();
            }
            if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
            {
                bossHealthBar.SetActive(true);
            }
        }
    }
}
