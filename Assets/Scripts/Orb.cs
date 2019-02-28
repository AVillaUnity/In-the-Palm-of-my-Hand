using UnityEngine;

public class Orb : MonoBehaviour
{
    [HideInInspector]
    public Entrance entrance;

    private ObjectPooler orbPooler;
    private MeshRenderer meshRenderer;
    [SerializeField]
    private bool isKey = false;
    private float emmisionValue = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        orbPooler = GetComponentInParent<ObjectPooler>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetAsKey()
    {
        isKey = true;
        meshRenderer.material.SetColor("_EmissionColor", Color.red * emmisionValue);
        //TODO: change to key material
    }

    public void ResetOrb()
    {
        isKey = false;
        meshRenderer.material.SetColor("_EmissionColor", Color.cyan * emmisionValue);
        transform.parent = orbPooler.inactiveParent;
        gameObject.SetActive(false);
        //TODO: revert to orb material
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isKey)
        {
            entrance.OpenHole();
        }

        ResetOrb();
    }
}
