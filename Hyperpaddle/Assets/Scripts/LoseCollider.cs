using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public Ball ball;

	void OnTriggerEnter () {
		audio.Play();
	}
}
