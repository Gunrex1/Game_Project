using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public GameObject gameOverUI; // Assign your Game Over UI in the Inspector
    public Text scoreText; // Assign a UI Text element in the Inspector
    private int score = 0; // To track the score

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndGame()
    {
        gameOverUI.SetActive(true); // Show the Game Over UI
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game!");
        Application.Quit(); // Works in a built application
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score Updated: " + score); // Log score updates for debugging

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the UI Text
        }
    }
}
