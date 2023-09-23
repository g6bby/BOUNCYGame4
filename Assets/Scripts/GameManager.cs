using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    public TextMeshProUGUI scoreText;
    

    private void Update()
    {
        scoreText.text = "Your score is: " + playerController.score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
