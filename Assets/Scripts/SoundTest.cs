using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour {

	public AudioClip soundFile;
	AudioSource mySound;

	public void mPlay(){
		mySound = GetComponent<AudioSource> ();
		mySound.Play ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
