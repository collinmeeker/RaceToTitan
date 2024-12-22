using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public float speed = 5.0f;
    public float leftBoundary = -10.25f;
    public Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        
        if (transform.position.x < leftBoundary)
        {
        
            transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        }
    }
}
