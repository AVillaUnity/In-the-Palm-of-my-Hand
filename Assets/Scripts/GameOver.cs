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
        if (other.GetComponent<LaunchPlanet>())
        {
            print("GameOver");
            Destroy(other.gameObject);
            // Wait for destruction animation
            Invoke("LoseGame", 0f);
        }
    }

    void LoseGame()
    {
        gameManager.LoadLevel("Lose Screen");
    }
}
