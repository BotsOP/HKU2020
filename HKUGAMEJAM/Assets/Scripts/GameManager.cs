using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float scorePlayer1;
    public float scorePlayer2;

    private void Update()
    {
        if(scorePlayer1 == 3)
        {
            Debug.Log("Player1 has won");
        }
        if(scorePlayer2 == 3)
        {
            Debug.Log("Player2 has won");
        }
    }
}
