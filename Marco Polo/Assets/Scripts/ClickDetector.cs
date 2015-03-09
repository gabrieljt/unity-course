using UnityEngine;
using System;
using System.Collections;

public class ClickDetector : MonoBehaviour {

	void Update () {
		if (PhotonNetwork.player.ID != GameLogic.playerWhoIsIt)
			return;

		if (Input.GetButton("Fire1")) {
			GameObject goPointedAt = RaycastObject(Input.mousePosition);

			if (goPointedAt != null && goPointedAt != gameObject && !goPointedAt.name.Equals("Plane", StringComparison.OrdinalIgnoreCase)) {
				PhotonView rootView = goPointedAt.transform.root.GetComponent<PhotonView>();
				GameLogic.TagPlayer(rootView.owner.ID);
			}

		}
	}

	private GameObject RaycastObject (Vector2 screenPosition) {
		RaycastHit info;

		if (Physics.Raycast(Camera.main.ScreenPointToRay(screenPosition), out info, 200))
			return info.collider.gameObject;
		return null;
	}
}
