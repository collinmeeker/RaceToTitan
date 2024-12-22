using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
    }

    public void PlayGame()
    {
    
        SceneManager.LoadScene("MainScene");
    }

   
    public void QuitGame()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }
}
