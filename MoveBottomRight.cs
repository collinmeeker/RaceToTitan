using UnityEngine;

public class MoveBottomRight : MonoBehaviour
{
    public float speed = 5f; 
    public float rightBoundary = 11.25f;
    public float bottomBoundary = -6.19f;
    public float rotationSpeed = 90.0f; 

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    
    void Update()
    {
     
        transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime, 0, Space.World);


        if (transform.position.x > rightBoundary || transform.position.y < bottomBoundary)
        {
            ReturnToStartPosition();
        }
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

    }
    public void ReturnToStartPosition()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
    }
}
