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
        bool PaperSawned = false;

        MeshCollider c = quad.GetComponent<MeshCollider>();

        screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

        loc = new Vector2(screenX, screenY);

        while (!PaperSawned)
        {
            Instantiate(page, loc, page.transform.rotation);
            PaperSawned = true;
        }

        /*for(int i = 0; i < 1; i++)
        {
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

            loc = new Vector2(screenX, screenY);

            Instantiate(page, loc, page.transform.rotation);
        }*/
    }
}
