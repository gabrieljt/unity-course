using UnityEngine;
using System.Collections;

public class MultiplayerGame : Photon.MonoBehaviour {

	private PhotonView scenePhotonView;

	void Start () {
		scenePhotonView = GetComponent<PhotonView>();
	}

	void OnJoinedRoom () {


	}
}
