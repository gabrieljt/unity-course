using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float velocity = 5f;
	public int direction = 1;

	void Update() 
	{
		transform.position += new Vector3(0f, direction * velocity * Time.deltaTime, 0f);
	}
}
