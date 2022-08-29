using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI _levelText;
    public static float _dropSpeed = 1.5f;
    public static int _currentLevel = 0;
    public static int _totalLinesCleared = 0;
    private static int MAX_LEVEL = 15;

    /// <summary>
    /// Set all the default values for the levelling system before the first frame.
    /// </summary>
    void Awake()
    {
        _levelText.text = "LEVEL:" + "\n" + _currentLevel.ToString();

        _dropSpeed = 1.5f;
        _currentLevel = 0;
        _totalLinesCleared = 0;
    }
    
    /// <summary>
    /// Update the scene every frame.
    /// </summary>
    void Update()
    {
        UpdateLevel();
    }

    /// <summary>
    /// Update the player's level depending on how many total lines are cleared.
    /// </summary>
    private void UpdateLevel()
    {
        int levelUpRequirement = (_currentLevel * 5) + 5;

        if(_currentLevel != MAX_LEVEL && _totalLinesCleared == levelUpRequirement)
        {
            _currentLevel++;
            _totalLinesCleared = 0;
            _levelText.text = "LEVEL:" + "\n" + _currentLevel.ToString();

            UpdateDropSpeed();
        }
    }

    /// <summary>
    /// Increase the player's drop speed by dividing it with a constant.
    /// The lower the drop speed, the faster an object will fall.
    /// </summary>
    private void UpdateDropSpeed()
    {
        _dropSpeed /= 1.25f;
    }
}