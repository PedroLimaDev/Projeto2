﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;

    public Vector3 offset = new Vector3(0, 0.5f, 0);

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;
	
    Vector3 pos;
	//bool shoot = false;

    // Start is called before the first frame update
    void Start()
    {
    	//Vector3 posPlayerShip = GameObject.Find("PlayerShip").transform.position;
        //pos = new Vector3(posPlayerShip.x, posPlayerShip.y, posPlayerShip.z);
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(Input.GetButton("Fire1") && cooldownTimer <= 0) {
        	Debug.Log("Pew");

        	//fireDelay = 0.25f;

        	cooldownTimer = fireDelay;

            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }

        /*if (shoot) {
        	pos.y += fireDelay;
        	transform.position = pos;

        }*/
    }
}