﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{

    public int scoreCount;
    public Text scoreTextPlayer1;
    public Text scoreTextPlayer2;
    GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreTextPlayer1 = GameObject.Find("Player1Score").GetComponent<Text>();
        scoreTextPlayer2 = GameObject.Find("Player2Score").GetComponent<Text>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        gm.Score++;
        scoreTextPlayer1.text = ("Player 1:") + gm.Score + (" / 5");
        scoreTextPlayer2.text = ("Player 2:") + gm.Score + (" / 5");
=======
        scoreCount += 1;
        scoreTextPlayer1.text = ("Player 1: ") + scoreCount + (" / 5");
        scoreTextPlayer2.text = ("Player 2: ") + scoreCount + (" / 5");
>>>>>>> cf838830b128a6da0d7b58e2714b0d7413a658f0

        Debug.Log("got the paper");
        Destroy(gameObject);
    }
}
