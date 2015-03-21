using UnityEngine;using System.Collections;public class Ball : MonoBehaviour {        public Paddle paddle;
    
    bool launched = false;
    Vector2 startVelocity;
    float speedMultiplier = 1.03f;

    void Start()
    {
        startVelocity = new Vector2(Random.Range(-20f, 20f), Random.Range(10f, 20f));
    }

    void Update()
    {
        if (!launched)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            Vector3 paddlePosition = paddle.transform.position;
            transform.position = new Vector3(paddlePosition.x, transform.position.y, 0f);

            if (Input.GetMouseButtonDown(0))
            {
                launched = true;
                GetComponent<Rigidbody2D>().velocity = startVelocity;
            }
        }        
    }    void OnCollisionEnter2D()    {
        GetComponent<Rigidbody2D>().velocity *= speedMultiplier;    }}