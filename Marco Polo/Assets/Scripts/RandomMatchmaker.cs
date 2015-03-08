using UnityEngine;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour {

	private PhotonView photonView;

	void Start () {
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnGUI () {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

		if (PhotonNetwork.connectionStateDetailed == PeerState.Joined) {
			if (GUILayout.Button("Marco!")) {
				photonView.RPC("Marco", PhotonTargets.All);
			}
			if (GUILayout.Button("Polo!")) {
				photonView.RPC("Polo", PhotonTargets.All);
			}
		}
	}

	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed() {
		Debug.Log("Could not connect to random room.");
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom() {
		GameObject monster = PhotonNetwork.Instantiate("monsterprefab", Vector3.zero, Quaternion.identity, 0);
		monster.GetComponent<myThirdPersonController>().isControllable = true;
		photonView = monster.GetComponent<PhotonView>();
	}
}
