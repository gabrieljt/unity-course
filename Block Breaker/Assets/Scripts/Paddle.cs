using UnityEngine;using System.Collections;public class Paddle : MonoBehaviour {

    public bool debug = false;

    private const float leftWorldBoundsOffset = 1.18f;
    private const float rightWorldBoundsOffset = 14.8f;
    private Ball ball;

    void Start()
    {
        Cursor.visible = false;
        ball = GameObject.FindObjectOfType<Ball>();
    }	void Update()     {
        if (!debug)
        {
            FollowMouse();
        }
        else
        {
            FollowBall();
        }        	}

    void FollowMouse()
    {
        float mousePositionInWorldUnits = Input.mousePosition.x / Screen.width * 16;
        Vector3 position = new Vector3(0f, transform.position.y, 0f);
        position.x = Mathf.Clamp(mousePositionInWorldUnits, leftWorldBoundsOffset, rightWorldBoundsOffset);
        transform.position = position;
    }

    void FollowBall()
    {
        transform.position = new Vector3(Mathf.Clamp(ball.transform.position.x, leftWorldBoundsOffset, rightWorldBoundsOffset), transform.position.y, transform.position.z);
    }

    void OnDestroy()
    {
        Cursor.visible = true;
    }}