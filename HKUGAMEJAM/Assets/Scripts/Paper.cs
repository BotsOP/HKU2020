using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{

    public int scoreCount;
    public Text scoreTextPlayer1;
    public Text scoreTextPlayer2;

    void Start()
    {
        scoreTextPlayer1 = GameObject.Find("Player1Score").GetComponent<Text>();
        scoreTextPlayer2 = GameObject.Find("Player2Score").GetComponent<Text>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        scoreCount += 1;
        scoreTextPlayer1.text = ("Player 1: ") + scoreCount + (" / 5");
        scoreTextPlayer2.text = ("Player 2: ") + scoreCount + (" / 5");

        Debug.Log("got the paper");
        Destroy(gameObject);
    }
}
