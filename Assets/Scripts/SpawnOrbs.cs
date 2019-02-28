using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnOrbs : MonoBehaviour
{
    public ObjectPooler orbPooler;
    public Transform[] orbSpawnPoints;

    private Entrance entrance;

    private void OnEnable()
    {
        entrance = GetComponent<Entrance>();
        Spawn();
    }

    void Spawn() {

        int keyIndex = Random.Range(0, orbSpawnPoints.Length);

        for(int i = 0; i < orbSpawnPoints.Length; i++)
        {
            GameObject orbObj = orbPooler.GetObject();
            Orb orb = orbObj.GetComponent<Orb>();

            orbObj.transform.parent = orbSpawnPoints[i];
            orbObj.transform.position = orbSpawnPoints[i].position;

            orb.entrance = entrance;
            if(i == keyIndex)
            {
                orb.SetAsKey();
            }
            orbObj.SetActive(true);
        }
    }

    public void RemoveOrbs()
    {
        foreach(Transform t in orbSpawnPoints)
        {
            Orb orb = GetComponentInChildren<Orb>();
            if (orb) { orb.ResetOrb(); }
        }
    }
}
