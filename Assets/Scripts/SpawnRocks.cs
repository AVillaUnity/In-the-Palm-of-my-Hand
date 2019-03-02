using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    public GameObject[] rocks;
    public static int rocksSpawned = 0;

    private int rocksActive = 0;

    private void OnEnable()
    {
        ScoreManager.instance.rockSpawner = this;
        if(rocksActive < rocksSpawned)
        {
            ActivateRock();
        }
    }

    public void Spawn()
    {
        rocksSpawned++;
        ActivateRock();
    }

    private void ActivateRock()
    {
        for(int i = rocksActive; i < rocksSpawned; i++)
        {
            rocks[i].SetActive(true);
            rocksActive++;
        }
    }

    
}
