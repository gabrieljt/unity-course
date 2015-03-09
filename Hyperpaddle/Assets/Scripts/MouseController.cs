using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	public Transform paddle;
	private float cameraToPaddleDistance;
	new public Camera camera;
	private CameraControl cameraControl;

	void Awake() {
		Setup(true);		
	}

	void Start () {
		if (camera == null)
		{
			Debug.LogError ("No camera assigned. Please correct and restart.");
			enabled = false;
			return;
		}
	}

	public void Setup (bool playerOne) {
		if (camera == null && Camera.main != null)
			camera = Camera.main;

		cameraToPaddleDistance = paddle.transform.position.z - camera.transform.position.z;
		if (!playerOne) cameraToPaddleDistance *= -1;
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
		
		paddle.transform.position = moveTo;
	}
}
