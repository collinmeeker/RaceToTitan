using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5.0f; 
    public float leftBoundary = -10.25f;
    public float rotationSpeed = 90.0f; 
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        
        transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        
        if (transform.position.x < leftBoundary)
        {
        
            transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        }
    }
}
