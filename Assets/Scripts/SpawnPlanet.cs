using UnityEngine;

public class SpawnPlanet : MonoBehaviour
{
    public GameObject[] planets;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int planetToSpawn = Random.Range(0, planets.Length);
        GameObject planet = Instantiate(planets[planetToSpawn], transform);
        planet.GetComponent<LaunchReady>().targetPosition = transform;
    }
}
