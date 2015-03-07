using UnityEngine;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour {

	void Start () {
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnGUI () {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed() {
		Debug.Log("Could not connect to random room.");
		PhotonNetwork.CreateRoom(null);
	}
}
