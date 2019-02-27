using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class LaunchPlanet : MonoBehaviour
{

    public float forwardForce = 2f;
    public float verticalForce = 3f;

    private bool launched = false;
    private Rigidbody rb;
    private LaunchReady launchReady;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        launchReady = GetComponent<LaunchReady>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!launched && launchReady.isReady && CrossPlatformInputManager.GetButtonDown("Jump")){
            launched = true;
            rb.useGravity = true;
            rb.velocity = (transform.parent.forward * forwardForce) + (transform.parent.up * verticalForce);
            transform.parent = null;
            rb.detectCollisions = true;
        }
    }
}
