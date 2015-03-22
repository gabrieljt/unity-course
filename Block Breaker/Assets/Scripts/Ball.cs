using UnityEngine;using System.Collections;public class Ball : MonoBehaviour {    private Paddle paddle;    private bool launched = false;    private Vector3 paddleToBallDistance;    private Vector2 startVelocity;
    private Vector2 funnyBounce;    private float speedMultiplier = 1.01f;    void Start()    {        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallDistance = transform.position - paddle.transform.position;        startVelocity = new Vector2(Random.Range(-5f, 5f), 5f);            }    void Update()    {        if (!launched)        {            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);            transform.position = paddle.transform.position + paddleToBallDistance;            if (Input.GetMouseButtonDown(0))            {                launched = true;                GetComponent<Rigidbody2D>().velocity = startVelocity;            }        }            }    void OnCollisionEnter2D(Collision2D collision)    {
        if (launched)
        {
            GetComponent<AudioSource>().Play();
            funnyBounce = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            GetComponent<Rigidbody2D>().velocity = (GetComponent<Rigidbody2D>().velocity + funnyBounce) * speedMultiplier;
        }    }}