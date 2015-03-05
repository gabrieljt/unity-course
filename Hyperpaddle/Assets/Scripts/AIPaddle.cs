using UnityEngine;
using System.Collections;

public class AIPaddle : MonoBehaviour {

	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<Ball>() as Ball;
	}

	void MovePaddleToBallPosition2D () {
		Vector3 moveTo;
		
		moveTo.x = Mathf.Clamp(ball.transform.position.x, -7.5f, 7.5f);
		moveTo.y = Mathf.Clamp(ball.transform.position.y, -7.5f, 7.5f);
		moveTo.z = transform.position.z;
		
		transform.position = moveTo;
	}
	
	// Update is called once per frame
	void Update () {
		MovePaddleToBallPosition2D();
	}
}
