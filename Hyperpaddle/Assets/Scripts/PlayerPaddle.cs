using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public Camera camera;
	private float cameraToPaddleDistance;

	// Use this for initialization
	void Start () {
		cameraToPaddleDistance = transform.position.z - camera.transform.position.z;
	}

	void OnMouseDrag () {
		Vector3 mousePosition = GetMouseCoordinatesAtDistance();
		MovePaddleTo(mousePosition);
	}

	Vector3 GetMouseCoordinatesAtDistance () {
		Vector3 mousePosition = Input.mousePosition;
		float mouseX = mousePosition.x;
		float mouseY = mousePosition.y;

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
	
	// Update is called once per frame
	void Update () {
	
	}
}
