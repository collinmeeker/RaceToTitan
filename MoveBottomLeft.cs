using UnityEngine;

public class MoveBottomLeft : MonoBehaviour
{
    public float speed = 5f; // Speed of the object
    public float leftBoundary = -10.25f;
    public float bottomBoundary = -6.19f;
    public float rotationSpeed = 90.0f; // Rotation speed in degrees per second

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement vector
        transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime, 0, Space.World);


        if (transform.position.x < leftBoundary || transform.position.y < bottomBoundary)
        {
            ReturnToStartPosition();
        }
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.World);
    }
    public void ReturnToStartPosition()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
    }
}
