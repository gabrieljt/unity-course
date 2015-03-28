using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	void OnDrawGizmos ()
	{
		Gizmos.DrawCube (transform.position, new Vector3 (1f, 1f, 1f));
	}

}
