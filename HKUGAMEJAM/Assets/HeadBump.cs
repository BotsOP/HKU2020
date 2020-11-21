using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpThrough")
        {
            Debug.Log(collision.name);
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpThrough")
        {
            Debug.Log("solidify");
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
