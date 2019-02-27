using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnOrbs : MonoBehaviour
{
    public ObjectPooler orbPooler;

    private Entrance entrance;

    private void OnEnable()
    {
        entrance = GetComponent<Entrance>();
        Spawn();
    }

    void Spawn() {

        int keyIndex = Random.Range(0, transform.childCount);
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject orbObj = orbPooler.GetObject();
            Orb orb = orbObj.GetComponent<Orb>();

            orbObj.transform.parent = orbPooler.activeParent;
            orbObj.transform.position = transform.GetChild(i).position;

            orb.entrance = entrance;
            if(i == keyIndex)
            {
                orb.SetAsKey();
            }
            orbObj.SetActive(true);
        }
    }
}
