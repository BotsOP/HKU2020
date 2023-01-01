using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogUp : MonoBehaviour
{
    public float speed;
    public float distance;
    public float distancedown;
    private bool movingRight = true;
    public Transform objectDetection;
    public Transform objectDetectionDown;
    const float playerRadius = 1.1f;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform playerCheck;
    public bool youCanWalk;

    private void Update()
    {
        youCanWalk = true;
        Collider2D[] playercolliders = Physics2D.OverlapCircleAll(playerCheck.position, playerRadius, whatIsPlayer);
        for (int i = 0; i < playercolliders.Length; i++)
        {
            if (playercolliders[i].gameObject != gameObject)
                youCanWalk = false;
        }
        if (youCanWalk == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }


        RaycastHit2D objectInfo = Physics2D.Raycast(objectDetection.position, Vector2.zero, distance);
        if ((objectInfo.collider == true) && (objectInfo.collider.tag == "ground"))
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(180, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(180, 0, 0);
                movingRight = true;
            }

        }
        RaycastHit2D objectInfoDown = Physics2D.Raycast(objectDetectionDown.position, Vector2.down, distancedown);
        if (objectInfoDown.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(180, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(180, 0, 0);
                movingRight = true;
            }

        }

    }
}
