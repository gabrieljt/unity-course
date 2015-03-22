using UnityEngine;using System.Collections;public class Paddle : MonoBehaviour {

    public bool debug;

    void Start()
    {
        Cursor.visible = false;
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
        position.x = Mathf.Clamp(mousePositionInWorldUnits, 0.5f, 15.5f);
        transform.position = position;
    }

    void FollowBall()
    {
        Vector3 ballPosition = GameObject.FindObjectOfType<Ball>().transform.position;
        transform.position = new Vector3(Mathf.Clamp(ballPosition.x, 0.5f, 15.5f), transform.position.y, transform.position.z);
    }

    void OnDestroy()
    {
        Cursor.visible = true;
    }}