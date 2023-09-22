using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            // Restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void IncreaseScore()
    {
        score++;
        // Update the score display here
    }

    public void GameOver()
    {
        isGameOver = true;
        // Display game over screen or perform other game over actions here
    }
}
