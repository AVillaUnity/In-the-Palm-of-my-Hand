using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RotateArm : MonoBehaviour
{
    public Transform handToRotate;
    public float startingSpeed;

    private float speed;
    private float maxSpeed;
    private Quaternion startingRotation;
    // Start is called before the first frame update
    void Start()
    {
        speed = startingSpeed;
        maxSpeed = startingSpeed * 1.5f;
        if(handToRotate == null)
        {
            handToRotate = transform;
        }
        startingRotation = handToRotate.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalTilt = CrossPlatformInputManager.GetAxis("Horizontal");
        float horizontalTilt = CrossPlatformInputManager.GetAxis("Vertical");

        if(CrossPlatformInputManager.GetButton("Horizontal") || CrossPlatformInputManager.GetButton("Vertical"))
        {
            speed += Time.deltaTime;
        }
        else
        {
            speed -= Time.deltaTime;
        }
        speed = Mathf.Clamp(speed, startingSpeed, maxSpeed);

        handToRotate.Rotate(-horizontalTilt * startingSpeed, 0f, verticalTilt * speed, Space.Self);
        handToRotate.rotation = Quaternion.Lerp(handToRotate.rotation, startingRotation, speed * Time.deltaTime);
    }
}
