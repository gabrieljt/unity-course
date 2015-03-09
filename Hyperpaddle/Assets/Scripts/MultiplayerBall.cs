using UnityEngine;
using System.Collections;

public class MultiplayerBall : Photon.MonoBehaviour {

	[Range (1f, 1.1f)]
	public float speedMultiplier = 1.03f;
	
	public Vector3 startVelocity = new Vector3(2.5f, 2.5f, -10f);
	public Vector3 funnyBounce = Vector3.zero;
	private Vector3 correctFunnyBounce = Vector3.zero;
	private Vector3 correctObjectVelocity = Vector3.zero;
	private Vector3 correctObjectPosition = new Vector3(0f, 0f, -50f);
	private Quaternion correctObjectRotation = Quaternion.identity;
	private bool resetting = false;
	
	void Start () {
		transform.position = new Vector3(0f, 0f, -50f);
		rigidbody.velocity = startVelocity;
	}
	
	void Update () {
		if (resetting) return;

		funnyBounce = correctFunnyBounce;
		rigidbody.velocity = correctObjectVelocity;
		transform.position = correctObjectPosition;
		transform.rotation = correctObjectRotation;
	}
	
	void OnCollisionEnter () {
		if (PhotonNetwork.isMasterClient)
			photonView.RPC("CollisionRPC", PhotonTargets.All);
	}

	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			stream.SendNext(funnyBounce);
			stream.SendNext(rigidbody.velocity);
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		} else {
			correctFunnyBounce = (Vector3) stream.ReceiveNext();
			correctObjectVelocity = (Vector3) stream.ReceiveNext();
			correctObjectPosition = (Vector3) stream.ReceiveNext();
			correctObjectRotation = (Quaternion) stream.ReceiveNext();
		}
	}

	[RPC]
	void CollisionRPC () {
		audio.Play();
		Accelerate();
	}

	[RPC]
	void ResetBallPosition () {
		resetting = true;
		funnyBounce = Vector3.zero;
		rigidbody.velocity = Vector3.zero;
		transform.position = new Vector3(0f, 0f, -50f);
		transform.rotation = Quaternion.identity;
		//yield return new WaitForSeconds(3f);
		Start();
		resetting = false;
	}

	void Accelerate () {
		Vector3 velocity = rigidbody.velocity;
		velocity.z *= speedMultiplier;
		
		funnyBounce.x = Random.Range(-5f, 5f);
		funnyBounce.y = Random.Range(-5f, 5f);
		rigidbody.velocity = velocity + funnyBounce;
	}
}
