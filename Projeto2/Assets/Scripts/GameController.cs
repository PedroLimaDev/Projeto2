﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour

// aqui ficarão as coisas de áudio também
// controla as coisas da cena do jogo

{
    // singleton
    #region Singleton
    private static GameController _instance;
    public static GameController Instance 
    {
        get
        {
            // create logic to create the instance
            if (_instance == null)
            {
                GameObject go = new GameObject("GameController");
                go.AddComponent<GameController>();
            }

            return _instance;
        } 
    }
    #endregion

    public delegate void DeadEnemy(); // observer
    public static event DeadEnemy onEnemyDead; // evento do observer inimigo morto

    public delegate void HitEnemy(); // observer
    public static event HitEnemy onEnemyHit; // evento do observer inimigo acertado

    public delegate void TimeIsOver(); // observer
    public static event TimeIsOver onLucioIsComing; // evento do observer tempo acabou - vez do Lúcio

	public Text scoreText;
	public Text countdown;

	public float time = 30;
	private int score = 0;
    
    //Tempo começa a contar a partir dessa pontuação
    public int scoreLimit = 10;

    public string status = "WAITING";
    public string spawner = "STOPPED";

    //ENEMY SPAWNER STATUS
    private string spawn = "SPAWNING";
    private string stop = "STOPPED";

    //COUNTDOWN STATUS
    private string wait = "WAITING";
    private string count = "COUNTING";

    public SpawnEnemies spawnEnemies;
    public PopupManager trigger;

    void Awake() 
    {
        _instance = this;
    }

    // Start is called before the first frame update

    void Start()
    {
    	//score = 0;
    	//time = 10;
    	scoreText.text = "Score: " + score.ToString();
        PauseMenu.GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
    	if(status.Equals(wait))
        {
           if(score >= scoreLimit)
           {
                //countdown.SetActive(true);
                trigger.StartDialog();
                status = count;
           }
        }

        else if(status.Equals(count))
        {
            UpdateTime();    
        }
    }

    void UpdateScore() 
    {
    	scoreText.text = "Score: " + score.ToString();
    }

    void UpdateTime() 
    {
    	if(time >= 0) 
    	{
            time -= Time.deltaTime;
    	    countdown.text = "Time: " + time.ToString("f0");
    		
    	}
        else
        {
            if (onLucioIsComing != null) 
            {
                onLucioIsComing();
            }
        }
    }

    public void AddScore(int newScoreValue) 
    {
    	score += newScoreValue;
    	UpdateScore();
    }
  
}
