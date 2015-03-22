﻿using UnityEngine;using System.Collections;public class Paddle : MonoBehaviour {

    void Start()
    {
        Cursor.visible = false;
    }	void Update()     {        float mousePositionInWorldUnits = Input.mousePosition.x / Screen.width * 16;        Vector3 position = new Vector3(0f, transform.position.y, 0f);        position.x = Mathf.Clamp(mousePositionInWorldUnits, 0.5f, 15.5f);        transform.position = position;	}

    void OnDestroy()
    {
        Cursor.visible = true;
    }}