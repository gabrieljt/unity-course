using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour {

    public AudioClip breakSound;
    public Sprite[] hitSprites;
    public GameObject onDestroyParticle;
    
    public static int breakableCount = 0;
    
    private LevelManager levelManager;
    private bool isBreakable;
    private int maxHits = 0;
    private int timesHit = 0;

	void Start()    
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (tag == "Breakable");

        if (isBreakable)
        {
            breakableCount++;
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
            HandleOnDestroyEffects();
            breakableCount--;
            Destroy(gameObject);
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }        
    }

    void HandleOnDestroyEffects()
    {
        AudioSource.PlayClipAtPoint(breakSound, transform.position, 0.15f);
        onDestroyParticle.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
        Instantiate(onDestroyParticle, transform.position, Quaternion.identity);
    }

    public void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick Hit Sprite is missing.");
        }
    }

}
