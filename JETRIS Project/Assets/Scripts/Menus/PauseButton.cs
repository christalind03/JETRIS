using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject _pauseMenu;

    public void OpenMenu()
    {
        if(Countdown._instance._countDownDone)
        {
            if(_pauseMenu != null)
            {
                PauseMenu._instance.Pause();
                _pauseMenu.SetActive(true);
            }
        }
    }
}
