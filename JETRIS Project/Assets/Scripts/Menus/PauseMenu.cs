using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu _instance;
    public GameObject _pauseMenuUI;
    public static bool _isGamePaused = false;

    /// <summary>
    /// Create a singleton instance before the first frame update.
    /// </summary>
    private void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// Allow the user to pause the game at any time.
    /// </summary>
    void Update()
    {
        // Disable esc key for three seconds for countdown
        if(Countdown._instance._countDownDone)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(_isGamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    /// <summary>
    /// Allow the user to resume the game.
    /// </summary>
    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isGamePaused = false;
    }

    /// <summary>
    /// Allow the user to pause the game.
    /// </summary>
    public void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isGamePaused = true;
    }

    /// <summary>
    /// Allow the user to go back to the menu.
    /// </summary>
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Allow the user to quit the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
