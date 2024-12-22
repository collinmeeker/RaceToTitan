using UnityEngine;

public class MoveTopRight : MonoBehaviour
{
    public float speed = 5f; // Speed of the object
    public float rightBoundary = 11.25f;
    public float topBoundary = 14.64f;
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
        transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0, Space.World);


        if (transform.position.x > rightBoundary || transform.position.y > topBoundary) {
            ReturnToStartPosition();
        }
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    public void ReturnToStartPosition() {
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
    }
}
