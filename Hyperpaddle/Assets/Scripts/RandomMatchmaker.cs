using UnityEngine;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour {

	public Camera playerOneCamera;
	private PhotonView playerOnePhotonView;

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
		Debug.Log("Could not connect to random room.");
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom () {
		GameObject playerOne = PhotonNetwork.Instantiate("Multiplayer Paddle", new Vector3(0f, 0f, -80), Quaternion.identity, 0);
		playerOne.GetComponent<MouseController>().camera = playerOneCamera;
		playerOnePhotonView = playerOne.GetComponent<PhotonView>();
	}
}
