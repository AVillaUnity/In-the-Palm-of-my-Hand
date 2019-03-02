using System.Collections;
using UnityEngine;

public class LaunchReady : MonoBehaviour
{
    public Vector2 xStartRange;
    public Vector2 zStartRange;
    public float speed = 10f;
    public bool isReady = false;
    public Transform targetPosition;
    public GameObject explosion;
    public Material explosiveMaterial;

    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private AudioManager audioManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        rb.detectCollisions = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(xStartRange.x, xStartRange.y), 0, Random.Range(zStartRange.x, zStartRange.y));
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        meshRenderer.material.SetColor("_EmissionColor", newColor * Mathf.GammaToLinearSpace(3.9f));
        explosiveMaterial.SetColor("_EmissionColor", newColor * Mathf.GammaToLinearSpace(3.9f));

        StartCoroutine(GoToPosition());
    }

    IEnumerator GoToPosition()
    {
        while(Vector3.Distance(transform.position, targetPosition.position) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
            yield return null;
        }
        isReady = true;
    }

    public void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (audioManager)
        {
            audioManager.Play("Explosion");
        }
    }
}
