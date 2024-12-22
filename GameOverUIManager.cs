using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverPanel; 

    void Start()
    {
        Cursor.visible = true;
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        Debug.Log("Showing Game Over Screen.");
        gameOverPanel.SetActive(true);
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
