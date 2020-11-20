using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThrough : MonoBehaviour
{
    public float decaySpeed = -2f;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().size += new Vector2(0f, decaySpeed);
            Debug.Log("touchy");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (GetComponent<BoxCollider2D>().size.y <= 0.5f)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
            Debug.Log("releas");
        }
    }
}
