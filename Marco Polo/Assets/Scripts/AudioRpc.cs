using UnityEngine;
using System.Collections;

public class AudioRpc : MonoBehaviour {

	public AudioClip marco;
	public AudioClip polo;

	[RPC]
	void Marco () {
		if (!enabled) return;

		Debug.Log("Marco");

		audio.clip = marco;
		audio.Play();
	}

	[RPC]
	void Polo () {
		if (!enabled) return;

		Debug.Log("Polo");
		
		audio.clip = polo;
		audio.Play();
	}
}
