using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;          // Speed at which the object falls
    public float lowerBoundary = -6.19f;    // The Y position where the object will reset
    public float rotationSpeed = 90.0f; // Rotation speed in degrees per second

    private Vector3 startPosition;          // To hold the original starting position

    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        // Move the object to the left
        transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);

        // Check if the object has reached the left boundary
        if (transform.position.y < lowerBoundary)
        {
            // Reset the position to the right (resetPositionX)
            transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        }
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}

