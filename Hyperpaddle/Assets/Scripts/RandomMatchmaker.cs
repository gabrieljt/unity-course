using UnityEngine;
using System;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour {

	private const string roomName = "HyperpaddleArena-";
	private PhotonView matchPhotonView;

	void Start () {
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnGUI () {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	void OnJoinedLobby () {
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed () {
		Debug.Log("No open matches available.");
		string newRoom = roomName + Guid.NewGuid().ToString("N");
		PhotonNetwork.CreateRoom(newRoom, true, true, 2);
		Debug.Log ("CreateRoom: " + newRoom);
	}
}
