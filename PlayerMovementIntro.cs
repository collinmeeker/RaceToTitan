using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the movement
    public float verticalDistance = 5.0f; // Vertical distance to move
    public float horizontalDistance = 5.0f; // Horizontal distance to move

    private Vector3 startPosition;
    private bool movingUpRight = true;
    private bool movingDownRight = false;
    private float traveledDistance = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        float step = speed * Time.deltaTime; // Calculate the step size

        if (movingUpRight)
        {
            Vector3 targetPosition = new Vector3(startPosition.x + horizontalDistance, startPosition.y + verticalDistance, startPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            traveledDistance += step;

            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                movingUpRight = false;
                movingDownRight = true;
                traveledDistance = 0f;
                startPosition = transform.position; // Update start position for next phase
            }
        }
        else if (movingDownRight)
        {
            Vector3 targetPosition = new Vector3(startPosition.x + horizontalDistance, startPosition.y - verticalDistance, startPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            traveledDistance += step;

            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                movingDownRight = false;
                movingUpRight = true;
                traveledDistance = 0f;
                startPosition = transform.position; // Update start position for next phase
            }
        }
    }
}
