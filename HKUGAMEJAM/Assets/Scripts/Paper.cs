using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    Text scoreTextPlayer1;
    Text scoreTextPlayer2;
    GameManager gm;
    bool shouldCollect = true;
    float startTime;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreTextPlayer1 = GameObject.Find("Player1Score").GetComponent<Text>();
        scoreTextPlayer2 = GameObject.Find("Player2Score").GetComponent<Text>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.name == "player 1")
            {
                gm.scorePlayer1 += 0.5f;
                scoreTextPlayer1.text = ("Player 1:") + gm.scorePlayer1 + (" / 5");
            }
            if(collision.gameObject.name == "player 2")
            {
                gm.scorePlayer2 += 0.5f;
                scoreTextPlayer1.text = ("Player 2:") + gm.scorePlayer2 + (" / 5");
            }
            GameObject.Find("PaperSpawner").GetComponent<Spawner>().SpawnNextPaper();
            Destroy(gameObject);
        }
    }
}
