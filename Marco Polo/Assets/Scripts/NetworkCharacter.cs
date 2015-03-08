using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	private Vector3 correctPlayerPosition;
	private Quaternion corretPlayerRotation;

	void Update () {
		if (!photonView.isMine) {
			transform.position = Vector3.Lerp(transform.position, correctPlayerPosition, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, corretPlayerRotation, Time.deltaTime * 5);
		}
	}

	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		} else {
			correctPlayerPosition = (Vector3) stream.ReceiveNext();
			corretPlayerRotation = (Quaternion) stream.ReceiveNext();
		}
	}
}
