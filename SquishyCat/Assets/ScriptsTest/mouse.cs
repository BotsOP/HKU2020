using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    const float playerRadius = 3f;
    const float playerExplodeRadius = 1.5f;
    public bool wakeUp;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private LayerMask whatIsPlayer;
    public bool explode;

    private void Start()
    {
        wakeUp = false;
    }


    private void Update()
    {

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] playercolliders = Physics2D.OverlapCircleAll(playerCheck.position, playerRadius, whatIsPlayer);
        for (int i = 0; i < playercolliders.Length; i++)
        {
            if (playercolliders[i].gameObject != gameObject)
                wakeUp = true;
        }
        if(wakeUp == true)
        {
            explode = false;
            Collider2D[] playerExplodeColliders = Physics2D.OverlapCircleAll(playerCheck.position, playerExplodeRadius, whatIsPlayer);
            for (int i = 0; i < playerExplodeColliders.Length; i++)
            {
                if (playerExplodeColliders[i].gameObject != gameObject)
                    explode = true;
            }
        }
        if(explode == true)
        {
            Debug.Log("BOOOM");
        }
    }
}
