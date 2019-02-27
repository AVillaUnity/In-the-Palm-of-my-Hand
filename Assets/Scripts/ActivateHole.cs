using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHole : MonoBehaviour
{
    public GameObject [] blackHoles;
    // Start is called before the first frame update
    void Start()
    {
        Activate();
    }

    public void Activate()
    {
        int holeToActivate = Random.Range(0, blackHoles.Length);
        foreach(GameObject go in blackHoles)
        {
            go.SetActive(false);
        }
        blackHoles[holeToActivate].SetActive(true);
    }
}
