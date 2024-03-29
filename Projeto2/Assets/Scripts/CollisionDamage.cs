﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDamage : MonoBehaviour
{
	public int health = 1;
	
	public float invulnPeriod;
	float invulnTimer = 0;

	int correctLayer;

	public int scoreValue;
	private GameController gameController;

    void Start(){
		correctLayer = gameObject.layer;

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if(gameController == null) 
		{
			Debug.Log("Cannot find Game Object script");
		}
	}	

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;       
    }

    void Update()
    {
    	invulnTimer -= Time.deltaTime;

    	if(invulnTimer <= 0)
    	{
    		gameObject.layer = correctLayer;
    	}

    	if(health <= 0)
        {
            //gameController.AddScore(scoreValue);
        	die();
        }
    }

    void die() {
		Destroy (gameObject); 
    }
}
