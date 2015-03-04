using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public Camera camera;
	private float worldUnitsFromCamera;

	// Use this for initialization
	void Start () {
		worldUnitsFromCamera = transform.position.z - camera.transform.position.z;
	}

	void OnMouseDrag () {
		Vector3 mousePosition = Input.mousePosition;
		float mouseX = mousePosition.x;
		float mouseY = mousePosition.y;
		Vector3 screenPosition = new Vector3 (mouseX, mouseY, worldUnitsFromCamera);

		Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);
		transform.position = worldPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
