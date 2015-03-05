using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	[Range (1f, 1.2f)]
	public float speedMultiplier = 1f;

	public Vector3 startVelocity;
	public Vector3 funnyBounce;

	void Start () {
		rigidbody.velocity = startVelocity;
	}

	void Accelerate () {
		Vector3 velocity = rigidbody.velocity;
		velocity.z *= speedMultiplier;

		funnyBounce.x = Random.Range(-5f, 5f);
		funnyBounce.y = Random.Range(-5f, 5f);
		rigidbody.velocity = velocity + funnyBounce;
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
