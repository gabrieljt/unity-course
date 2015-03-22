using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefabs;

	void Start() 
	{
		SpawnPosition[] spawnPositions = GameObject.FindObjectsOfType<SpawnPosition>();

		foreach(SpawnPosition spawnPosition in spawnPositions)
		{
			GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
			                               spawnPosition.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = transform;
		}
	}

}
