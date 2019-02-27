using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    [HideInInspector]
    public bool isOpen = false;

    private SpawnPlanet planetSpawner;
    private ActivateHole activateHole;

    private void Start()
    {
        activateHole = GetComponentInParent<ActivateHole>();
        planetSpawner = GameObject.FindObjectOfType<SpawnPlanet>();
    }


    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (isOpen)
        {
            print("Planet Entered Hole");
        }
        else
        {
            print("Planet did not enter hole");
        }

        Destroy(other.gameObject);
        planetSpawner.Spawn();
        activateHole.Activate();
    }
}
