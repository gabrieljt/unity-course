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

	[RPC]
	void ResetBallPosition () {
		ball.rigidbody.velocity = Vector3.zero;
		ball.transform.position = new Vector3(0f, 0f, -22f);
		ball.rigidbody.velocity = ball.GetComponent<Ball>().startVelocity;
		
	}

	public static void NewRound () {
		if (PhotonNetwork.isMasterClient)
			scenePhotonView.RPC("ResetBallPosition", PhotonTargets.All);
	}
}
