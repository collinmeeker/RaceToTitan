using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public float radius = 5.0f;  // Radius of the circular path
    public float speed = 1.0f;   // Speed of the movement along the circular path

    private Vector3 centerPosition;

    void Start()
    {
        centerPosition = transform.position;  // Set the center position
    }

    void Update()
    {
        float x = centerPosition.x + Mathf.Cos(Time.time * speed) * radius;
        float y = centerPosition.y + Mathf.Sin(Time.time * speed) * radius;
        transform.position = new Vector3(x, y, transform.position.z);  // Update position to move in a circle
    }
}
