using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float scorePlayer1;
    public float scorePlayer2;

    private void Update()
    {
        if(scorePlayer1 == 10)
        {
            Debug.Log("Player1 has won");
            SceneManager.LoadScene("Player1Wins");
        }
        if(scorePlayer2 == 5)
        {
            Debug.Log("Player2 has won");
            SceneManager.LoadScene("Player2Wins");
        }
    }
}
