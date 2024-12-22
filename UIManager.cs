using UnityEngine;
using TMPro;  // Include the TextMeshPro namespace

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI livesText;
    public PlayerController playerController;
    public GameManager gameManager;

    void Update()
    {
        if (playerController != null && livesText != null)
        {
            livesText.text = "Lives: " + playerController.lives;
        }

        if (gameManager != null && levelText != null)
        {
            levelText.text = "Level: " + gameManager.getCurrentLevel();
        }
    }
}
