using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject page;
    public Vector2 loc;
    float screenX, screenY;
    public GameObject quad;

    

    void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();

        for(int i = 0; i < 1; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

            loc = new Vector2(screenX, screenY);

            Instantiate(page, loc, page.transform.rotation);
        }
    }
}
