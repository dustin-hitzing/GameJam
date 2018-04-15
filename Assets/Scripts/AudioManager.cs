using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioClip startingSounds;
    public AudioClip backgroundMusic;
    public AudioSource MusicSource;

	// Use this for initialization
	void Start() 
	{
		Debug.Log("I live");
		Debug.Log(MusicSource.enabled);
		Debug.Log(MusicSource.clip);
	    // StartCoroutine(playIntro());
	}
	IEnumerator playIntro() {
		MusicSource.clip = startingSounds;
		MusicSource.Play();
		yield return new WaitForSeconds(MusicSource.clip.length);
		MusicSource.clip = backgroundMusic;
		MusicSource.Play();
	}
}
