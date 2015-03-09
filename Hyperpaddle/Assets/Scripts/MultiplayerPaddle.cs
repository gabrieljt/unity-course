﻿using UnityEngine;
using System.Collections;

public class MultiplayerPaddle : Photon.MonoBehaviour {

	[Range (1f, 10f)]
	public float lerpMultiplier = 1f;

	private Vector3 correctObjectPosition;
	private Quaternion corretObjectRotation;
	
	void Update () {
		if (!photonView.isMine) {
			transform.position = Vector3.Lerp(transform.position, correctObjectPosition, Time.deltaTime * lerpMultiplier);
			transform.rotation = Quaternion.Lerp(transform.rotation, corretObjectRotation, Time.deltaTime * lerpMultiplier);
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
