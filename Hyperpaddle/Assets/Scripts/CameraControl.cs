using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	[Range (0.05f, 0.5f)]

	public float factor;

	public void ShiftAroundPaddle (Vector3 position) {
		Vector3 moveTo;
		
		moveTo.x = Mathf.Clamp(position.x * factor, -10f, 10f);
		moveTo.y = Mathf.Clamp(position.y * factor, -10f, 10f);
		moveTo.z = transform.position.z;
		
		transform.position = moveTo;
	}
}
