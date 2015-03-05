using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 startVelocity;

	void Start () {
		rigidbody.velocity = startVelocity;
	}

	void OnCollisionEnter () {
		audio.Play();
	}
}
