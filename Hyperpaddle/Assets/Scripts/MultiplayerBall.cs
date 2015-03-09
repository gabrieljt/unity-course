using UnityEngine;
using System.Collections;

public class MultiplayerBall : Photon.MonoBehaviour {


	[Range (1f, 1.1f)]
	public float speedMultiplier = 1.03f;
	
	public Vector3 startVelocity = new Vector3(0f, 0f, -10f);
	public Vector3 funnyBounce = new Vector3(0f, 0f, 0f);
	private Vector3 correctObjectPosition;
	private Quaternion corretObjectRotation;
	private Vector3 correctObjectVelocity;
	private Vector3 correctObjectFunnyBounce;
	
	void Start () {
		rigidbody.velocity = startVelocity;
		Accelerate();
	}

	void Update () {
		if (PhotonNetwork.playerList.Length == 1) 
			Reset();

		if (!photonView.isMine) {
			transform.position = correctObjectPosition;
			transform.rotation = corretObjectRotation;
			rigidbody.velocity = correctObjectVelocity;
			funnyBounce = correctObjectFunnyBounce;
		}
	}
	
	void OnCollisionEnter () {
		if (PhotonNetwork.isMasterClient)
			GetComponent<PhotonView>().RPC("CollisionRPC", PhotonTargets.All);
	}

	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(rigidbody.velocity);
			stream.SendNext(funnyBounce);
		} else {
			correctObjectPosition = (Vector3) stream.ReceiveNext();
			corretObjectRotation = (Quaternion) stream.ReceiveNext();
			correctObjectVelocity = (Vector3) stream.ReceiveNext();
			correctObjectFunnyBounce = (Vector3) stream.ReceiveNext();
		}
	}

	public void Accelerate () {
		Vector3 velocity = rigidbody.velocity;
		velocity.z *= speedMultiplier;
		
		funnyBounce.x = Random.Range(-5f, 5f);
		funnyBounce.y = Random.Range(-5f, 5f);
		rigidbody.velocity = velocity + funnyBounce;
	}

	public void Reset () {
		rigidbody.velocity = Vector3.zero;
		transform.position = new Vector3(0f, 0f, -50f);
		transform.rotation = Quaternion.identity;
		funnyBounce = Vector3.zero;
	}

	[RPC]
	void CollisionRPC () {
		audio.Play();
		Accelerate();
	}
}
