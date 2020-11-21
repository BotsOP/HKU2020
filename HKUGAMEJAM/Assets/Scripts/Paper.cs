using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    Text scoreTextPlayer1;
    Text scoreTextPlayer2;
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
        gm.Score++;
        scoreTextPlayer1.text = ("Player 1:") + gm.Score + (" / 5");
        scoreTextPlayer2.text = ("Player 2:") + gm.Score + (" / 5");

        Debug.Log("got the paper");
        Destroy(gameObject);
    }
}
