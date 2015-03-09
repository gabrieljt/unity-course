using UnityEngine;
using System.Collections;

public class MultiplayerGame : Photon.MonoBehaviour {

	public MultiplayerBall ball;
	private static PhotonView scenePhotonView;
	
	void Start () {
		scenePhotonView = GetComponent<PhotonView>();
	}
	
	void OnJoinedRoom () {
		GameObject paddle = PhotonNetwork.Instantiate("Multiplayer Paddle", Vector3.zero, Quaternion.identity, 0);
		Camera paddleCamera = paddle.GetComponent<MouseController>().camera;
		
		if (PhotonNetwork.isMasterClient) {
			paddle.transform.position = new Vector3(0f, 0f, -80f);
			paddle.GetComponent<MouseController>().Setup(true);			
		} else {
			paddle.transform.position = new Vector3(0f, 0f, -20f);
			paddle.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
			paddleCamera.transform.position = new Vector3(0f, 0f, 0f);			
			paddleCamera.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
			paddle.GetComponent<MouseController>().Setup(false);
		}
		paddle.GetComponent<MouseController>().isControllable = true;

		if (PhotonNetwork.playerList.Length == 2)
			NewRound();
	}
	
	[RPC]
	void ResetBallPosition () {			
		ball.Reset();
		ball.rigidbody.velocity = ball.startVelocity;
	}
	
	public static void NewRound () {
		if (PhotonNetwork.isMasterClient) {
			scenePhotonView.RPC("ResetBallPosition", PhotonTargets.All);
		}
	}
}
