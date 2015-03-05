using UnityEngine;
using System.Collections;

public class AIPaddle : MonoBehaviour {

	public GameObject ball;
	private Vector3 ballPosition;

	// Use this for initialization
	void Start () {
		MovePaddleToBallPosition2D();
	}

	void MovePaddleToBallPosition2D () {
		ballPosition = ball.transform.position;	
		ballPosition.z = transform.position.z;

		Vector3 moveTo;
		
		moveTo.x = Mathf.Clamp(ballPosition.x, -7.5f, 7.5f);
		moveTo.y = Mathf.Clamp(ballPosition.y, -7.5f, 7.5f);
		moveTo.z = ballPosition.z;
		
		transform.position = moveTo;
	}
	
	// Update is called once per frame
	void Update () {
		MovePaddleToBallPosition2D();
	}
}
