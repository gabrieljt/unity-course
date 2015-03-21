﻿using UnityEngine;
    
    private bool launched = false;
    private Vector3 paddleToBallDistance;
    private Vector2 startVelocity;
    private float speedMultiplier = 1.03f;

    void Start()
    {
        startVelocity = new Vector2(Random.Range(-5f, 5f), Random.Range(5f, 10f));
        paddleToBallDistance = transform.position - paddle.transform.position;
    }

    void Update()
    {
        if (!launched)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            transform.position = paddle.transform.position + paddleToBallDistance;

            if (Input.GetMouseButtonDown(0))
            {
                launched = true;
                GetComponent<Rigidbody2D>().velocity = startVelocity;
            }
        }        
    }
        GetComponent<Rigidbody2D>().velocity *= speedMultiplier;