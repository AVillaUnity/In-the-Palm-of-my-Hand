using UnityEngine;

public class AttachToHand : MonoBehaviour
{
    public Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = hand;
    }
}
