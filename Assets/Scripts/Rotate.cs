using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 1f;

    private bool rotate = true;

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
        }
    }
}
