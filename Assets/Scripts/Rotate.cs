using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float initialSpeed = 10f;
    public bool randomRotation = false;

    // Random Rotation variables
    private Vector3 rotationValue;
    private float minRotationSpeed = 0f;
    private float maxRotationSpeed = 1f;

    // Normal Rotation variables
    private float speed;
    private float maxSpeed;

    private void Start()
    {
        rotationValue = new Vector3(Random.Range(minRotationSpeed, maxRotationSpeed), Random.Range(minRotationSpeed, maxRotationSpeed), Random.Range(minRotationSpeed, maxRotationSpeed));
        speed = initialSpeed;
        maxSpeed = initialSpeed * 2;
    }
    // Update is called once per frame
    void Update()
    {
        if (randomRotation)
        {
            transform.Rotate(rotationValue, Space.Self);
        }
        else
        {
            if (Input.GetButton("Speed"))
            {
                speed += Time.deltaTime * 10;
            }
            else
            {
                speed -= Time.deltaTime * 15;
            }
            speed = Mathf.Clamp(speed, initialSpeed, maxSpeed);
            transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.Self);
        }
    }
}
