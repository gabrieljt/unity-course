using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float velocity = 5f;
	public GameObject laser;

	private float leftBoundary, rightBoundary, paddingX, paddingY;

	void Start()
	{
		SetBounds();
	}

	void Update() 
	{
		HandleInput();
	}

	void HandleInput()
	{
		Vector3 position = transform.position;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			position.x -= velocity * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			position.x += velocity * Time.deltaTime;
		}

		transform.position = new Vector3(Mathf.Clamp(position.x, leftBoundary, rightBoundary), 
		                                 position.y, position.z);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(laser, new Vector3(position.x, position.y + paddingY, position.z), 
			            Quaternion.identity);
		}
	}

	void SetBounds()
	{
		Camera camera = Camera.main;
		float shipToCameraDistance = transform.position.z - camera.transform.position.z;
		paddingX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.5f;
		paddingY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * 0.5f;
		
		leftBoundary = camera.ViewportToWorldPoint(new Vector3(0f, 0f, shipToCameraDistance)).x + paddingX;
		rightBoundary = camera.ViewportToWorldPoint(new Vector3(1f, 1f, shipToCameraDistance)).x - paddingX;
	}

}
