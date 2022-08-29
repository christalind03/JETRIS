using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager _instance;
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _comboText;

    public int _combo = 0;
    public int _score = 0;
    public int _highScore = 0;

    /// <summary>
    /// Create a singleton instance before the first frame update.
    /// </summary>
    private void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// Set and display the current score to the user before the first frame update.
    /// </summary>
    void Start()
    {
        _highScore = PlayerPrefs.GetInt("Highscore");
        _scoreText.text = "SCORE:" + "\n" + _score.ToString();
    }

    /// <summary>
    /// Update the combo score every frame update.
    /// The combo score gets added every time a line is cleared.
    /// </summary>
    void Update(){
        if(_combo > 4)
        {
            _combo = 1;
        }

        if(_combo > 1 && _combo < 5)
        {
            _comboText.text = "COMBO x " + _combo.ToString();
        }
    }

    /// <summary>
    /// Add a point to the score depending on its combo value and display the information to the user.
    /// </summary>
    public void AddPoint()
    {
        UpdateCombo();
        UpdateScore();
        UpdateHighScore();
    }

    /// <summary>
    /// Update the combo score.
    /// The combo score cannot exceed past x4.
    /// </summary>
    private void UpdateCombo()
    {
        if(_combo > 4)
        {
            _combo = 1;
        }
        
        _combo = _combo + 1;

        if(_combo > 1 && _combo < 5)
        {
            _comboText.text = "COMBO x " + _combo.ToString();
        }

        if(_combo == 5)
        {
            _comboText.text = "";
        }
    }

    /// <summary>
    /// Update the score based on the current combo score.
    /// Display the new score.
    /// </summary>
    private void UpdateScore()
    {
        _score += 100 * _combo;
        _scoreText.text = "SCORE :" + "\n" + _score.ToString();
    }

    /// <summary>
    /// Update the high score if the current score is greater than the high score.
    /// </summary>
    private void UpdateHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
        }
    }   
}
    
