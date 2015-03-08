using UnityEngine;
using System.Collections;

public class GameLogic : Photon.MonoBehaviour {

	public static int playerWhoIsIt;
	private static PhotonView scenePhotonView;

	void Start () {
		scenePhotonView = GetComponent<PhotonView>();
	}

	void OnPhotonPlayerConnected (PhotonPlayer player) {
		Debug.Log("OnPhotonPlayerConnected: " + player);

		if (PhotonNetwork.isMasterClient)
			TagPlayer(playerWhoIsIt);
	}

	void OnJoinedRoom () {
		if (PhotonNetwork.playerList.Length == 1)
			playerWhoIsIt = PhotonNetwork.player.ID;
		Debug.Log("playerWhoIsIt: " + playerWhoIsIt);
	}

	[RPC]
	void TaggedPlayer (int playerID) {
		playerWhoIsIt = playerID;
		Debug.Log("TaggedPlayer: " + playerWhoIsIt);
	}

	public static void TagPlayer (int playerID) {
		Debug.Log ("TagPlayer: " + playerID);
		scenePhotonView.RPC("TaggedPlayer", PhotonTargets.All, playerID);
	}
}
