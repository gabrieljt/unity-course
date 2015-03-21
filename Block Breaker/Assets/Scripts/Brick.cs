using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour {

    public int maxHits;
    public int timesHit = 0;

	void Start()
    {
        maxHits = Convert.ToInt32(name.Split(' ')[0]);
	}
	
	void Update() 
    {
        if (timesHit == maxHits)
            Destroy(gameObject);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
    }

}
