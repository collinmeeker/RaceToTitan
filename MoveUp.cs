using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 5.0f;          // Speed at which the object falls
    public float upperBoundary = 5.64f;    // The Y position where the object will reset
    public float rotationSpeed = 90.0f; // Rotation speed in degrees per second
    private Vector3 startPosition;          // To hold the original starting position

    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        // Move the object to the left
        transform.Translate(0, speed * Time.deltaTime, 0, Space.World);

        // Check if the object has reached the left boundary
        if (transform.position.y > upperBoundary)
        {
            // Reset the position to the right (resetPositionX)
            ReturnToStartPosition();
        }
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

    }
    public void ReturnToStartPosition()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
    }
}

