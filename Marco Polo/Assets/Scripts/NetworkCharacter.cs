using UnityEngine;
using System.Collections;

public class NetworkCharacter : MonoBehaviour {

	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		} else {
			transform.position = stream.ReceiveNext() as Vector3;
			transform.rotation = stream.ReceiveNext() as Quaternion;
		}
	}
}
