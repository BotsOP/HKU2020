using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public float speed;
    public float distance;
    public float distancedown;
    private bool movingRight = true;
    public Transform objectDetection;
    public Transform objectDetectionDown;


    private void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D objectInfo = Physics2D.Raycast(objectDetection.position, Vector2.zero, distance);
        if ((objectInfo.collider == true))
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
            
        }
        RaycastHit2D objectInfoDown = Physics2D.Raycast(objectDetectionDown.position, Vector2.down, distancedown);
        if ((objectInfoDown.collider == false))
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

        }

    }
}
