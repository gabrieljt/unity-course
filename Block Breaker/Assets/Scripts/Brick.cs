using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour {

    private LevelManager levelManager;
    private static int bricksCount;
    private int maxHits;
    private int timesHit = 0;

	void Start()    
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        bricksCount = GameObject.FindObjectsOfType<Brick>().Length;
        maxHits = Convert.ToInt32(name.Split(' ')[0]);
	}
	
    void OnCollisionEnter2D()
    {
        timesHit++;

        if (timesHit == maxHits)
        {
            Destroy(gameObject);
            bricksCount--;
        }

        if (bricksCount == 0)
        {
            levelManager.LoadNextLevel();
        }
    }

}
