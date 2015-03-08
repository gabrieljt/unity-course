using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public static int playerWhoIsIt;

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
}
