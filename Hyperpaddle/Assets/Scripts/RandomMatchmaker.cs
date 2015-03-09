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

	void OnJoinedRoom () {
		GameObject paddle = PhotonNetwork.Instantiate("Multiplayer Paddle", Vector3.zero, Quaternion.identity, 0);
		Camera paddleCamera = paddle.GetComponent<MouseController>().camera;
		
		if (PhotonNetwork.playerList.Length == 1) {
			paddle.transform.position = new Vector3(0f, 0f, -80f);
			paddle.GetComponent<MouseController>().Setup(true);
			
		} else {
			paddle.transform.position = new Vector3(0f, 0f, -20f);
			paddle.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
			paddleCamera.transform.position = new Vector3(0f, 0f, 0f);			
			paddleCamera.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
			paddle.GetComponent<MouseController>().Setup(false);
		}

		matchPhotonView = paddle.GetComponent<PhotonView>();		
	}
}
