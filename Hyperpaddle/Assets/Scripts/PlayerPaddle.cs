using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public ScoreKeeper scoreKeeper;
	public Camera camera;
	private float cameraToPaddleDistance;
	private CameraControl cameraControl;

	void Start () {
		cameraToPaddleDistance = transform.position.z - camera.transform.position.z;
		cameraControl = camera.GetComponent<CameraControl>() as CameraControl;
	}

	void OnMouseDrag () {
		Vector3 mousePosition = GetMouseCoordinatesAtDistance();
		MovePaddleTo(mousePosition);
		cameraControl.ShiftAroundPaddle(mousePosition);		
	}

	Vector3 GetMouseCoordinatesAtDistance () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;

		Vector3 screenPosition = new Vector3(mouseX, mouseY, cameraToPaddleDistance);		
		Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);

		return worldPosition;
	}

	void MovePaddleTo (Vector3 worldPosition) {
		Vector3 moveTo;

		moveTo.x = Mathf.Clamp(worldPosition.x, -7.5f, 7.5f);
		moveTo.y = Mathf.Clamp(worldPosition.y, -7.5f, 7.5f);
		moveTo.z = worldPosition.z;

		transform.position = moveTo;
	}

	void OnCollisionEnter () {
		scoreKeeper.Add(1);
	}
}
