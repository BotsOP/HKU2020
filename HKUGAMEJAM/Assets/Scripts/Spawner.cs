using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject paper;
    [SerializeField] GameObject[] paperPositions;

    void Start()
    {
        SpawnNextPaper();
    }

    public void SpawnNextPaper()
    {
        int indexInt = Random.Range(0,paperPositions.Length);
        Debug.Log(indexInt);
        Instantiate(paper, paperPositions[indexInt].transform.position, Quaternion.identity);
    }
}
