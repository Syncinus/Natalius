using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongRunner : MonoBehaviour {
    public AudioSource Source;

    public void Awake()
    {
        StartCoroutine(awake());
    }

    private IEnumerator awake()
    {
        yield return new WaitUntil(() => this.GetComponent<GameController>().MusicCheck == true);
        Source.time = transform.GetComponent<GameController>().StartTime;

        Source.pitch = GameSettings.GameSpeed;
        Source.Play();
    }
}
