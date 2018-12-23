using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneController : MonoBehaviour {

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	public void StartRecording () {
		audioSource.Stop ();
		audioSource.clip = Microphone.Start ("", false, 10, 44100);
	}

	public void Play () {
		if (!Microphone.IsRecording ("")) {
			if (audioSource.clip != null) {
				audioSource.Play ();
			}
		}
	}

	public void StopRecording () {
		if (Microphone.IsRecording ("")) {
			Microphone.End ("");
		}
	}
}
