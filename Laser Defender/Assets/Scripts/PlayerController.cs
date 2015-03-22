using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float velocity = 0.15f;

	void Update () 
	{
		HandleInput();
	}

	void HandleInput()
	{
		Vector3 position = transform.position;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			position.x -= velocity;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			position.x += velocity;
		}

		transform.position = new Vector3(Mathf.Clamp(position.x, -6.15f, 6.15f), position.y, position.z);
	}

}
