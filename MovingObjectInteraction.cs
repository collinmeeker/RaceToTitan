using UnityEngine;

public class MovingObjectInteraction : MonoBehaviour
{
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision object has the "Player" tag
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit the player!");
            InteractWithPlayer(collision);
        }
        // Optionally check for wall to ignore interaction
        else if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Hit a wall, ignoring...");
        }
        
    }

    private void InteractWithPlayer(Collision2D collision)
    { 
        collision.gameObject.GetComponent<PlayerController>().Die();
        
    }
}
