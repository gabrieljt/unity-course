using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	[Range (1f, 1.2f)]
	public float speedMultiplier;

	public Vector3 startVelocity;

	void Start () {
		rigidbody.velocity = startVelocity;
	}

	void Accelerate () {
		Vector3 velocity = rigidbody.velocity;
		velocity.z *= speedMultiplier;

		rigidbody.velocity = velocity;
	}

	void OnCollisionEnter () {
		audio.Play();
		Accelerate();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))
			speedMultiplier = Mathf.Clamp(speedMultiplier + 0.01f, 1f, 1.2f);
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			speedMultiplier = Mathf.Clamp(speedMultiplier - 0.01f, 1f, 1.2f);
	}
}
