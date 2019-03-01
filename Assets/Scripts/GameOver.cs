using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        LaunchReady planet = other.GetComponent<LaunchReady>();
        if (other.GetComponent<LaunchPlanet>())
        {
            planet.Die();
            Destroy(other.gameObject);
            Invoke("LoseGame", 0f);
        }
    }

    void LoseGame()
    {
        gameManager.LoadLevel("Lose Screen");
    }
}
