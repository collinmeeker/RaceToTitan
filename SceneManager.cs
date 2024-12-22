using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameSceneName"); // Replace "GameSceneName" with your actual game scene name
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
