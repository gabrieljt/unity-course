using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;

    private LevelManager levelManager;
    private static int bricksCount;
    private int maxHits;
    private int timesHit = 0;

	void Start()    
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        bricksCount = GameObject.FindObjectsOfType<Brick>().Length;
        maxHits = hitSprites.Length + 1;
	}
	
    void OnCollisionEnter2D()
    {
        timesHit++;

        if (timesHit == maxHits)
        {
            Destroy(gameObject);
            bricksCount--;
        }
        else
        {
            LoadSprites();
        }

        if (bricksCount == 0)
        {
            levelManager.LoadNextLevel();
        }
    }

    public void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

}
