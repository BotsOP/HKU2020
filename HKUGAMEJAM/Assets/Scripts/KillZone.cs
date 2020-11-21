using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.name == "player 1")
            {
                collision.transform.position = spawnPoint.position;
            }
            if (collision.gameObject.name == "player 2")
            {
                collision.transform.position = spawnPoint.position;
            }
        }
    }
}
