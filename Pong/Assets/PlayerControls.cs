using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;

	public float speed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 velocity = rigidbody2D.velocity;

		if (Input.GetKey (moveUp)) {
			velocity.y = speed;
		} else if (Input.GetKey (moveDown)) {
			velocity.y = -1 * speed;
		} else if (!Input.anyKey) {
			velocity.y = 0.0f;
		}	

		velocity.x = 0.0f;
		rigidbody2D.velocity = velocity;
	}
}
