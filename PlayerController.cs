
using UnityEngine;
using System.Collections; 


public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    
    public int lives;

    void Start()
    {
        lives = 5;

        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager == null)
            {
                Debug.LogError("GameManager not found in the scene.");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //Debug.Log("Hit a wall! Lives left: " + lives);
            //Die();
        }
    }

    public void Die()
    {
        if (gameManager != null)
        {
            //in here
            gameManager.HandlePlayerDeath(gameObject);
            
        }
    }


    public void GameOver()
    {

        Cursor.visible = true;
        gameObject.SetActive(false);
        Debug.Log("Gameover!");
        
        
    }
}
