using UnityEngine;
using System.Collections;

public class MultiplayerBall : Photon.MonoBehaviour {

	private Vector3 correctObjectPosition;
	private Quaternion corretObjectRotation;
	
	void Update () {
		if (!photonView.isMine) {
			transform.position = correctObjectPosition;
			transform.rotation = corretObjectRotation;
		}
	}
	
	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		} else {
			correctObjectPosition = (Vector3) stream.ReceiveNext();
			corretObjectRotation = (Quaternion) stream.ReceiveNext();
		}
	}
}
