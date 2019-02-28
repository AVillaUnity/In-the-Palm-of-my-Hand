using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LaunchPlanet>())
        {
            print("GameOver");
            Destroy(other.gameObject);
        }
    }
}
