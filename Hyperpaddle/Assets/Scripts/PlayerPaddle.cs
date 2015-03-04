using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDrag () {
		print ("Dragged to " + Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
