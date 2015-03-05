using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 startVelocity;

	// Use this for initialization
	void Start () {
		startVelocity = new Vector3(0.0f, 0.0f, -40.0f);
		rigidbody.velocity = startVelocity;
	}

	// Update is called once per frame
	void Update () {
	}
}
