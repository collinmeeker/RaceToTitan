using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  
    public GameManager gameManager;
    private bool isPaused = false;
    public PlayerController playerController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
            
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        playerController.Die();
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;  // Resume normal time
        
    }

    public void Pause()
    {
        Cursor.visible = true;
        isPaused = true;
        Debug.Log("Paused.");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;  // Freeze the game
        
    }
    public void Restart() {
        
        Time.timeScale = 1f;  // Resume normal time
        SceneManager.LoadScene("MainScene");

    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
