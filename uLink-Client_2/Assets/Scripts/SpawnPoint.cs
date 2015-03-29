using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject playerPrefab;

	void OnDrawGizmos ()
	{
		Gizmos.DrawCube (transform.position, new Vector3 (1f, 1f, 1f));
	}

	void uLink_OnConnectedToServer ()
	{
		playerPrefab = uLink.Network.Instantiate (playerPrefab, transform.position, transform.rotation, 0);
		playerPrefab.GetComponent<MultiplayerController> ().isControllable = true;
		Debug.Log ("Network aware player's object instantiated by client");
	}

}
