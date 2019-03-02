using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    [HideInInspector]
    public bool isOpen = false;
    public GameObject blackHole;
    public SpawnOrbs orbSpawner;
    public int scoreForEntrance = 3;

    private SpawnPlanet planetSpawner;
    private ActivateHole activateHole;
    private float emmisionValue = 2f;
    private GameManager gameManager;
    private ScoreManager scoreManager;
    private MeshRenderer holeMeshRenderer;
    private ParticleSystemRenderer holeParticleSystem;



    private void Start()
    {
        scoreManager = ScoreManager.instance;
        activateHole = GetComponentInParent<ActivateHole>();
        planetSpawner = GameObject.FindObjectOfType<SpawnPlanet>();
        orbSpawner = GetComponent<SpawnOrbs>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        holeMeshRenderer = blackHole.GetComponent<MeshRenderer>();
        holeParticleSystem = blackHole.GetComponent<ParticleSystemRenderer>();
        holeMeshRenderer.material.SetColor("_EmissionColor", Color.red * emmisionValue);
        holeParticleSystem.material.SetColor("_EmissionColor", Color.red * emmisionValue);
    }

    public void OpenHole()
    {
        isOpen = true;
        holeMeshRenderer.material.SetColor("_EmissionColor", Color.green * emmisionValue);
        holeParticleSystem.material.SetColor("_EmissionColor", Color.green * emmisionValue);

    }


    private void OnTriggerEnter(Collider other)
    {
        LaunchReady planet = other.GetComponent<LaunchReady>();
        if (planet)
        {
            if (isOpen)
            {
                scoreManager.IncrementScore(scoreForEntrance);
                orbSpawner.RemoveOrbs();
                planetSpawner.Spawn();
                isOpen = false;
                activateHole.Activate();
                // TODO: Add entrance effect
            }
            else
            {
                planet.Die();
                Invoke("LoseGame", 0f);
            }

            Destroy(other.gameObject);
            holeMeshRenderer.material.SetColor("_EmissionColor", Color.red * emmisionValue);
            holeParticleSystem.material.SetColor("_EmissionColor", Color.red * emmisionValue);
        }
    }

    void LoseGame()
    {
        gameManager.LoadLevel("Lose Screen");
    }
}
