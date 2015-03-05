using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 startVelocity;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = startVelocity;
	}

	// Update is called once per frame
	void Update () {
	}
}
