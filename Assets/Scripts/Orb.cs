using UnityEngine;

public class Orb : MonoBehaviour
{
    [HideInInspector]
    public Entrance entrance;

    private ObjectPooler orbPooler;
    [SerializeField]
    private bool isKey = false;

    // Start is called before the first frame update
    void Start()
    {
        orbPooler = GetComponentInParent<ObjectPooler>();
    }

    public void SetAsKey()
    {
        isKey = true;
        //TODO: change to key material
    }

    public void ResetOrb()
    {
        isKey = false;
        //TODO: revert to orb material
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isKey)
        {
            entrance.isOpen = true;
        }

        ResetOrb();
        transform.parent = orbPooler.inactiveParent;
        gameObject.SetActive(false);
        
    }
}
