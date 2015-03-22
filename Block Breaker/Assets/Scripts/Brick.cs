using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;

    private LevelManager levelManager;
    private static int bricksCount;
    private int maxHits = 0;
    private int timesHit = 0;
    bool isBreakable;

	void Start()    
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = tag.Equals("Breakable");

        if (isBreakable)
        {
            bricksCount = GameObject.FindGameObjectsWithTag("Breakable").Length;
            maxHits = hitSprites.Length + 1;
        }        
	}
	
    void OnCollisionEnter2D()
    {
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
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
        if (hitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

}
