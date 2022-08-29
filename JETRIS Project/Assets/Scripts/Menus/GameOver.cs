using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _highScoreText;

    /// <summary>
    /// Displays all the necessary information for the Game Over screen before the first frame update.
    /// </summary>
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Game Over");

        SaveHighScore();

        _scoreText.text = "SCORE : " + ScoreManager._instance._score.ToString();
        _highScoreText.text = "HIGH SCORE : " + ScoreManager._instance._highScore.ToString();
    }

    /// <summary>
    /// Allows the user to save their highest score.
    /// </summary>
    public void SaveHighScore()
    {
        GameObject manager = GameObject.Find("GameManagers");

        UnityMainThreadDispatcher.Instance().Enqueue(() => 
        {
            PlayerPrefs.SetInt("Highscore", ScoreManager._instance._highScore);
        });
    }


    /// <summary>
    /// Allows the user to play the game again.
    /// </summary>
    public void PlayAgainButton()
    {
        SceneManager.LoadScene("Single Player");
    }

    /// <summary>
    /// Allows the user to return back to the main menu.
    /// </summary>
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    } 
}