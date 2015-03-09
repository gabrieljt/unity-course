using UnityEngine;
using System.Collections;

public class MultiplayerGame : Photon.MonoBehaviour {

	private static GameObject ball;
	private static PhotonView scenePhotonView;

	void Start () {
		scenePhotonView = GetComponent<PhotonView>();
	}

	void OnJoinedRoom () {
		if (PhotonNetwork.playerList.Length == 2) {
			ball = PhotonNetwork.Instantiate("Multiplayer Ball", new Vector3(0f, 0f, -22f), Quaternion.identity, 0);
			NewRound();
		}
	}

	void OnPhotonPlayerConnected (PhotonPlayer player) {

	}



	public static void NewRound () {
		if (PhotonNetwork.isMasterClient)
			ball.GetComponent<PhotonView>().RPC("ResetBallPosition", PhotonTargets.All);
	}
}
