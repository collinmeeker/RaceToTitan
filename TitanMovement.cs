using System.Collections;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float tiltAngle = 30.0f;  // Maximum tilt angle to each side
    public float tiltSpeed = 2.0f;   // Speed of tilting left and right
    public float forwardSpeed = 5.0f;  // Speed at which the ship will move forward

    private bool startMovingForward = false;  // Control flag for forward movement

    void Start()
    {
        // Start the tilting coroutine
        StartCoroutine(TiltShip());
    }

    void Update()
    {
        if (startMovingForward)
        {
            // Move the ship forward
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
    }

    IEnumerator TiltShip()
    {
        // Perform tilting left and right 3 times
        
        while (true)
        {
            // Tilt to the right
            yield return RotateOverTime(tiltAngle, tiltSpeed);
            // Tilt back to the left
            yield return RotateOverTime(-tiltAngle * 2, tiltSpeed);
            // Return to center
            yield return RotateOverTime(tiltAngle, tiltSpeed);

        }


        
    }

    IEnumerator RotateOverTime(float targetAngle, float duration)
    {
        float time = 0;
        float startAngle = transform.eulerAngles.z;
        float endAngle = startAngle + targetAngle;

        while (time < duration)
        {
            float zRotation = Mathf.Lerp(startAngle, endAngle, time / duration);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
            time += Time.deltaTime;
            yield return null;
        }

        // Snap to the exact final angle to avoid small calculation errors
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, endAngle);
    }
}
