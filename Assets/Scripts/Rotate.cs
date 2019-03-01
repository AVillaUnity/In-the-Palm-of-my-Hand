using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float initialSpeed = 10f;
    public bool randomRotation = false;
    public bool rotateAroundSun = false;

    // Random Rotation variables
    private Vector3 rotationValue;
    private float minRotationSpeed = 10f;
    private float maxRotationSpeed = 30f;
    private float direction = 0f;

    // Normal Rotation variables
    private float speed;
    private float maxSpeed;

    private Transform sun;


    private void Start()
    {
        rotationValue = new Vector3(Random.Range(minRotationSpeed, maxRotationSpeed), Random.Range(minRotationSpeed, maxRotationSpeed), Random.Range(minRotationSpeed, maxRotationSpeed));
        speed = initialSpeed;
        maxSpeed = initialSpeed * 3;

        if (rotateAroundSun) { sun = GameObject.FindGameObjectWithTag("Sun").transform; }
        direction = (Random.Range(0, 2) > 0) ? 1 : -1;
    }
    // Update is called once per frame
    void Update()
    {
        if (randomRotation)
        {
            transform.Rotate(rotationValue * Time.deltaTime, Space.Self);
        }
        else if(!rotateAroundSun)
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

        if (rotateAroundSun)
        {
            transform.RotateAround(sun.position, transform.right, Random.Range(100f, 200f) * direction * Time.deltaTime);
        }
    }
}
