using UnityEngine;
using System.Collections;

public class MultiplayerController : MonoBehaviour {

	public bool isControllable = false;
	public Transform player;
	new public Camera camera;

	private float cameraToPlayerDistance;
	
	void Awake () 
	{
		if (camera == null && Camera.main != null)
			camera = Camera.main;
		
		cameraToPlayerDistance = player.transform.position.z - camera.transform.position.z;
	}
	
	void Start ()
	{
		if (camera == null)
		{
			Debug.LogError ("No camera assigned. Please correct and restart.");
			enabled = false;
			return;
		}
	}
	
	void OnMouseDrag () 
	{
		if (isControllable) 
		{
			Vector3 worldPosition = GetMouseCoordinatesAtDistance();
			player.transform.position = worldPosition;
		}
	}
	
	Vector3 GetMouseCoordinatesAtDistance () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		
		Vector3 screenPosition = new Vector3(mouseX, mouseY, cameraToPlayerDistance);		
		Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);
		
		return worldPosition;
	}
	
}
