using UnityEngine;using System.Collections;public class Ball : MonoBehaviour {        public Paddle paddle;
    
    private bool launched = false;
    private Vector3 paddleToBallDistance;
    private Vector2 startVelocity;
    private float speedMultiplier = 1.03f;

    void Start()
    {
        startVelocity = new Vector2(Random.Range(-20f, 20f), Random.Range(10f, 20f));
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
    }    void OnCollisionEnter2D()    {
        GetComponent<Rigidbody2D>().velocity *= speedMultiplier;    }}