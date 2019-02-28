using UnityEngine;

public class SqueezeHand : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Squeeze", Input.GetAxis("Speed"));
    }
}
