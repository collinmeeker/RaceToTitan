using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 5.0f; 
    public float rotationSpeed = 90.0f; 
    public float rightBoundary = 11.25f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World); 

        
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        
        if (transform.position.x > rightBoundary)
        {
        
            ReturnToStartPosition();
        }
    }

    public void ReturnToStartPosition()
    {
        transform.position = startPosition;
        
        transform.rotation = Quaternion.identity; 
    }
}
