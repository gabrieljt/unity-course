using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float factor;
	private PlayerPaddle playerPaddle;

	// Use this for initialization
	void Start () {
		playerPaddle = FindObjectOfType<PlayerPaddle>() as PlayerPaddle;
		ShiftAroundPaddle(playerPaddle.transform.position);
	}

	void ShiftAroundPaddle (Vector3 paddlePosition) {
		Vector3 moveTo;
		
		moveTo.x = Mathf.Clamp(paddlePosition.x, -7.5f, 7.5f);
		moveTo.y = Mathf.Clamp(paddlePosition.y, -7.5f, 7.5f);
		moveTo.z = transform.position.z;
		
		transform.position = moveTo;
	}

	// Update is called once per frame
	void Update () {
		ShiftAroundPaddle(playerPaddle.transform.position);	
	}
}
