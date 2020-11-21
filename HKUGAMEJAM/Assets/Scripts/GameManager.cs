using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score;

    private void Update()
    {
        if(Score == 5)
        {
            Debug.Log("Player has won");
        }
    }
}
