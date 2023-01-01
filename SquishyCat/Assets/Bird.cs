using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed;
    public float jumpForce = 400f;
    public float distance;
    public float distancedown;
    private bool movingRight = true;
    public Transform objectDetection;
    public Transform objectDetectionDown;
    public Transform objectDetectionUp;
    public float startPos;
    private Rigidbody2D rb2d;
    public float pos;
    public int count = 0;
    public bool MyFunctionCalled = false;
    public bool MyFunctionCalledDive = false;
    public bool MyFunctionCalledHeavy = false;

    private void Start()
    {
        startPos = transform.position.y;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        pos = transform.position.y;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D objectInfoHeavy = Physics2D.Raycast(objectDetectionUp.position, Vector2.up, distance);
        if (objectInfoHeavy.collider == true)
        {
            if (MyFunctionCalledHeavy == false)
            {

                MyFunctionCalledHeavy = true;
                startPos -= 1000;
            }
        }
        if (objectInfoHeavy.collider == false)
        {
            if (MyFunctionCalledHeavy == true)
            {

                MyFunctionCalledHeavy = false;
                startPos += 1000;
            }
        }
        RaycastHit2D objectInfo = Physics2D.Raycast(objectDetection.position, Vector2.right, distance);
        if (objectInfo.collider == true)
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
        RaycastHit2D objectInfoDown = Physics2D.Raycast(objectDetectionDown.position, Vector2.right, distance);
        if (objectInfoDown.collider == true)
        { 
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0f, jumpForce));
            if (MyFunctionCalled == false)
            {
                MyFunctionCalled = true;
            }
        }

        if (pos <= startPos)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0f, jumpForce));
            if(MyFunctionCalled == false)
            { 
                MyFunctionCalled = true;
            }

        }
        if (pos >= startPos)
        {
            if (MyFunctionCalled == true)
            {

                MyFunctionCalled = false;
                count += 1;
            }

        }
        if (count == 1)
        {
            if(MyFunctionCalledDive == false)
            {
                startPos -= 2;
                MyFunctionCalledDive = true;
            }
            
        }
        if (count == 2)
        {
            if (MyFunctionCalledDive == true)
            {
                startPos += 2;
                MyFunctionCalledDive = false;
            }
        }
        if(count == 5)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
        }
        if (count == 6)
        {
            if (MyFunctionCalledDive == false)
            {
                startPos -= 2;
                MyFunctionCalledDive = true;
            }

        }
        if (count == 7)
        {
            if (MyFunctionCalledDive == true)
            {
                startPos += 2;
                MyFunctionCalledDive = false;
            }
        }
        if (count == 10)
        {
            if (movingRight == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
            count = 0;
        }


    }
}
