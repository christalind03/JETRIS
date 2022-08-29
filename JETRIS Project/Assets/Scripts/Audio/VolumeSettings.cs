using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public static VolumeSettings _instance;
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _gameMusicSlider;

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_GAME = "GameVolume";

    public float _gameVolume;

    /// <summary>
    /// Automatically set values for volume sliders.
    /// </summary>
    void Awake()
    {
        _instance = this;

        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _gameMusicSlider.onValueChanged.AddListener(SetGameMusicVolume);
    }

    /// <summary>
    /// Adjust the main menu volume.
    /// </summary>
    /// <param name="value"> The volume slider position. </param>
    void SetMusicVolume(float value)
    {
        _mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    /// <summary>
    /// Adjust the game volume.
    /// </summary>
    /// <param name="value"> The volume slider position. </param>
    void SetGameMusicVolume(float value)
    {
        _mixer.SetFloat(MIXER_GAME, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("GameV", value);        
        _gameVolume = PlayerPrefs.GetFloat("GameV");
    }

}
