using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float velocity = 5f;
	public int direction = 1;

	private float bottomBoundary, topBoundary;

	void Start()
	{
		SetBounds();
	}

	void Update() 
	{
		transform.position += new Vector3(0f, direction * velocity * Time.deltaTime, 0f);

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
