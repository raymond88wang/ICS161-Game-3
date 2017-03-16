using UnityEngine;

public class BossFightStart : MonoBehaviour {

    public GameObject bossHealthBar;
    public Animator animator;
    private AudioSource bossBattle;
    private GameObject boss;
    private GameObject player1;
    private GameObject player2;

    private void Awake()
    {
        bossBattle = GetComponentInChildren<AudioSource>();
        boss = GameObject.Find("Boss");
        bossHealthBar.SetActive(false);
        animator = transform.parent.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Game Music").GetComponent<AudioSource>().Stop();
        if(!bossBattle.isPlaying && boss != null && (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2")))
        {
            if(other.gameObject.CompareTag("Player1"))
                player1 = other.gameObject;
            if(other.gameObject.CompareTag("Player2"))
                player2 = other.gameObject;

            if(player1 != null && player2 != null)
            {
                bossHealthBar.SetActive(true);
                bossBattle.Play();
                animator.SetTrigger("Close");
                DestroyObject(GetComponents<BoxCollider>()[1]);
                DestroyObject(GetComponents<BoxCollider>()[0]);
            }
        }
    }
}
