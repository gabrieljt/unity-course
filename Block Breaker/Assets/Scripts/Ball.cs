using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    void OnCollisionEnter()
    {
        Debug.Log("Ball collided.");
    }
}
