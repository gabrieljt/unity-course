using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float velocity = 5f;
	public int direction = 1;

	private float bottomBoundary, topBoundary;

	void Awake()
	{
		SetBounds();
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, direction * velocity);		
	}

	void Update() 
	{
		if (transform.position.y < bottomBoundary || transform.position.y > topBoundary)
			Destroy(gameObject);
	}

	void SetBounds()
	{
		Camera camera = Camera.main;
		float laserToCameraDistance = transform.position.z - camera.transform.position.z;
		
		bottomBoundary = camera.ViewportToWorldPoint(new Vector3(0f, 0f, laserToCameraDistance)).y;
		topBoundary = camera.ViewportToWorldPoint(new Vector3(1f, 1f, laserToCameraDistance)).y;
	}
}
