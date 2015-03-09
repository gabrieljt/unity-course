using UnityEngine;
using System.Collections;

public class MultiplayerPaddle : Photon.MonoBehaviour {

	[Range (1f, 10f)]
	public float lerpMultiplier = 5f;

	private Vector3 correctObjectPosition;
	private Quaternion correctObjectRotation;
	
	void Update () {
		if (!photonView.isMine) {
			transform.position = Vector3.Lerp(transform.position, correctObjectPosition, Time.deltaTime * lerpMultiplier);
			transform.rotation = Quaternion.Lerp(transform.rotation, correctObjectRotation, Time.deltaTime * lerpMultiplier);
		}
	}
	
	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		} else {
			correctObjectPosition = (Vector3) stream.ReceiveNext();
			correctObjectRotation = (Quaternion) stream.ReceiveNext();
		}
	}
}
