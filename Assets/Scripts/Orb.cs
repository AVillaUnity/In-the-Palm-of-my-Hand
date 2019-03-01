using UnityEngine;

public class Orb : MonoBehaviour
{
    [HideInInspector]
    public Entrance entrance;
    public AudioClip collectNoise;
    public AudioClip keyNoise;
    public ParticleSystem ps;
    public int scoreForOrb = 1;
    public int scoreForKey = 2;

    private ObjectPooler orbPooler;
    private MeshRenderer meshRenderer;
    private ScoreManager scoreManager;
    private Color orbColor;
    private bool isKey = false;
    private float emmisionValue = 3.5f;

    // Start is called before the first frame update
    void Awake()
    {
        scoreManager = ScoreManager.instance;
        orbPooler = GetComponentInParent<ObjectPooler>();
        meshRenderer = GetComponent<MeshRenderer>();
        ps.gameObject.SetActive(false);
        orbColor = meshRenderer.material.GetColor("_EmissionColor");
    }

    public void SetAsKey()
    {
        isKey = true;
        meshRenderer.material.SetColor("_EmissionColor", Color.red * Mathf.GammaToLinearSpace(emmisionValue));
        ps.gameObject.SetActive(true);
    }

    public void ResetOrb()
    {
        isKey = false;
        meshRenderer.material.SetColor("_EmissionColor", orbColor);
        transform.parent = orbPooler.inactiveParent;
        gameObject.SetActive(false);
        ps.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isKey)
        {
            AudioSource.PlayClipAtPoint(keyNoise, transform.position);
            entrance.OpenHole();
            scoreManager.IncrementScore(scoreForKey);
        }
        else
        {
            scoreManager.IncrementScore(scoreForOrb);
        }
        AudioSource.PlayClipAtPoint(collectNoise, transform.position);
        ResetOrb();
    }
}
