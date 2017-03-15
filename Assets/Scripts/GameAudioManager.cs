using System.Collections;
using UnityEngine;

public class GameAudioManager : MonoBehaviour {
    private AudioSource gameMusic;

	private void Awake () {
        gameMusic = GetComponent<AudioSource>();
	}

    IEnumerator StartGameMusicAgain()
    {
        yield return new WaitForSeconds(4);
        gameMusic.Play();
    }
}
