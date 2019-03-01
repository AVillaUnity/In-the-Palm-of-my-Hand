using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    [HideInInspector]
    public bool isOpen = false;
    public MeshRenderer meshRenderer;
    public SpawnOrbs orbSpawner;

    private SpawnPlanet planetSpawner;
    private ActivateHole activateHole;
    private float emmisionValue = 2f;
    private GameManager gameManager;

    private void Start()
    {
        activateHole = GetComponentInParent<ActivateHole>();
        planetSpawner = GameObject.FindObjectOfType<SpawnPlanet>();
        orbSpawner = GetComponent<SpawnOrbs>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        meshRenderer.material.SetColor("_EmissionColor", Color.red * emmisionValue);
    }

    public void OpenHole()
    {
        isOpen = true;
        meshRenderer.material.SetColor("_EmissionColor", Color.green * emmisionValue);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LaunchPlanet>())
        {
            if (isOpen)
            {
                print("Planet Entered Hole");
                orbSpawner.RemoveOrbs();
                planetSpawner.Spawn();
                isOpen = false;
                activateHole.Activate();
                // TODO: Add entrance effect
            }
            else
            {
                print("Planet did not enter hole");
                // TODO Add destruction effect
                // Wait for destruction animation
                Invoke("LoseGame", 0f);
            }

            Destroy(other.gameObject);
            meshRenderer.material.SetColor("_EmissionColor", Color.red * emmisionValue);
        }
    }

    void LoseGame()
    {
        gameManager.LoadLevel("Lose Screen");
    }
}
