using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour {

    private int maxHits;
    private int timesHit = 0;

	void Start()
    {
        maxHits = Convert.ToInt32(name.Split(' ')[0]);
	}
	
    void OnCollisionEnter2D()
    {
        timesHit++;
        
        if (timesHit == maxHits)
            Destroy(gameObject);
    }

}
