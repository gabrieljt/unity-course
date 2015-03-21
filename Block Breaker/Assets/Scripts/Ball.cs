using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    void OnCollisionEnter2D()
    {
        Debug.Log("Ball collided.");
    }
}
