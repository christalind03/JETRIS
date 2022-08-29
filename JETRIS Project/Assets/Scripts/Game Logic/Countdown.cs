using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public static Countdown _instance;
    public int _countdownTime;
    public TextMeshProUGUI _countDownDisplay;
    public bool _countDownDone;

    /// <summary>
    /// Create a singleton instance before the first frame update.
    /// </summary>
    void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// Starts and displays the countdown to the user.
    /// </summary>
    void Start()
    {
        StartCoroutine(CountdownToStart());
    }
    
    /// <summary>
    /// Starts and displays the countdown to the user.
    /// This uses a return value of IEnumerator in order to take advantage of the WaitForSeconds() function.
    /// </summary>
    /// <returns></returns>
    private IEnumerator CountdownToStart()
    {
        // Display countdown text
        while(_countdownTime > 0)
        {
            _countDownDisplay.text = _countdownTime.ToString();
            yield return new WaitForSeconds(1f);

            _countdownTime--;
        }

        _countDownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);

        if(_countdownTime == 0)
        {
            _countDownDone = true;
        }

        _countDownDisplay.gameObject.SetActive(false);
    }
}
