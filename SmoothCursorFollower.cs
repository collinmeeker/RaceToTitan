using UnityEngine;

public class SmoothCursorFollower : MonoBehaviour
{
    public float smoothSpeed = 5.0f; // Control the rate of smoothing

    private void Start()
    {
        Debug.Log("Cursor set off.");
        Cursor.visible = false;
    }

    void Update()
    {

        // Convert the mouse position to world coordinates
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0; // Ensure the z-position is set correctly for a 2D setup

        // Smoothly interpolate from the current position to the cursor position
        transform.position = Vector3.Lerp(transform.position, cursorPos, smoothSpeed * Time.deltaTime);
    }

}
