using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

	public GameObject[] enemyPrefabs;
	public float width = 12f;
	public float height = 4.5f;
	public float velocity = 1.25f;

	private float leftWorldBounds, rightWorldBounds;
	private bool movingLeft = true;

	void Start() 
	{
		SetWorldBounds();

		foreach(Transform child in transform)
		{
			GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
			                               child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void Update()
	{
		Vector3 position = transform.position;

		if (position.x == leftWorldBounds)
		{
			movingLeft = false;
		}
		else if (position.x == rightWorldBounds)
		{
			movingLeft = true;
		}

		if (movingLeft)
		{
			position.x -= velocity * Time.deltaTime;
		}
		else
		{
			position.x += velocity * Time.deltaTime;
		}
		
		transform.position = new Vector3(Mathf.Clamp(position.x, leftWorldBounds, rightWorldBounds), position.y, position.z);
	}

	void SetWorldBounds()
	{
		Camera camera = Camera.main;
		float formationToCameraDistance = transform.position.z - camera.transform.position.z;
		
		leftWorldBounds = camera.ViewportToWorldPoint(new Vector3(0f, 0f, formationToCameraDistance)).x;
		rightWorldBounds = camera.ViewportToWorldPoint(new Vector3(1f, 1f, formationToCameraDistance)).x - width;
	}

	void OnDrawGizmos()
	{
		float leftBounds, rightBounds, topBounds, bottomBounds;
		leftBounds 		= width  * 0.5f + (transform.position.x - 0.5f * width);
		rightBounds 	= width  * 0.5f + (transform.position.x + 0.5f * width);
		topBounds 		= height * 0.5f + (transform.position.y - 0.5f * height);
		bottomBounds 	= height * 0.5f + (transform.position.y + 0.5f * height);

		Gizmos.DrawLine(new Vector3(leftBounds, bottomBounds, 0f), 	new Vector3(leftBounds, topBounds, 0f));
		Gizmos.DrawLine(new Vector3(leftBounds, topBounds, 0f), 	new Vector3(rightBounds, topBounds, 0f));
		Gizmos.DrawLine(new Vector3(rightBounds, topBounds, 0f), 	new Vector3(rightBounds, bottomBounds, 0f));
		Gizmos.DrawLine(new Vector3(rightBounds, bottomBounds, 0f),	new Vector3(leftBounds, bottomBounds, 0f));
	}

}
