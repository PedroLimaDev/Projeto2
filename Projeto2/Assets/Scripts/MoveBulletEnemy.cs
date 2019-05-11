﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletEnemy : MonoBehaviour
{

    public float maxSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
       Vector3 pos = transform.position; 

       Vector3 velocity = new Vector3(maxSpeed * Time.deltaTime, 0, 0);

       pos -= velocity;

       transform.position = pos;
    }
}