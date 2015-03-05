using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	[Range (1f, 1.1f)]
	public float speedMultiplier = 1.03f;

	public Vector3 startVelocity = new Vector3(2.5f, 2.5f, -20f);
	public Vector3 funnyBounce = new Vector3(0f, 0f, 0f);

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
			speedMultiplier = Mathf.Clamp(speedMultiplier + 0.01f, 1f, 1.1f);
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			speedMultiplier = Mathf.Clamp(speedMultiplier - 0.01f, 1f, 1.1f);
	}
}
