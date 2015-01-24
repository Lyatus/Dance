using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(AudioSource))]
public class PlayMovie : MonoBehaviour {
	public MovieTexture movie;
	public string nextScene;
	
	void Start () {
		GetComponent<Renderer>().material.mainTexture = movie;
		GetComponent<AudioSource>().clip = movie.audioClip;
		movie.Play();
		GetComponent<AudioSource>().Play();
	}
	void Update(){
		if(!movie.isPlaying || Input.anyKeyDown)
			Application.LoadLevel(nextScene);
	}
}
