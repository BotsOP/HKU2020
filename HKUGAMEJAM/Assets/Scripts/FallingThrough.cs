using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThrough : MonoBehaviour
{
    [SerializeField] float timeToRespawn;
    [SerializeField] float decreasePlatform;
    bool shouldLerp = false;
    bool shouldStartTime;
    float startTime;
    float newY;
    Vector2 oriSize;
    BoxCollider2D boxcol;

    void Start()
    {
        boxcol = GetComponent<BoxCollider2D>();
        oriSize = boxcol.size;
    }

    void Update()
    {
        //Debug.Log(newY);
        //if(shouldLerp)
        //{
        //    shouldStartTime = false;
        //    newY = Mathf.Lerp(oriSize.y, 0, Time.time - (startTime));
        //    if (Time.time - startTime > 2)
        //    {
        //        shouldLerp = false;
        //        newY = oriSize.y;
        //        shouldStartTime = true;
        //    }
        //    boxcol.size = new Vector2(oriSize.x, newY);

        //}

        if(boxcol.size.y < 0.01 && Time.time - startTime > timeToRespawn)
        {
            boxcol.size = oriSize;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Feet")
        {
            startTime = Time.time;
            boxcol.size -= new Vector2(0, decreasePlatform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(oriSize + "test2");
        boxcol.size = oriSize;
    }


}
