using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup _audioOutput;
    public Sound[] _soundClips;

    /// <summary>
    /// Creates a new audio source for each sound clip given by the array from the game object's inspector.
    /// This function also adjusts the sound clip's volume and whether or not it loops.
    /// </summary>
    void Awake()
    {
        foreach(Sound soundClip in _soundClips)
        {
            soundClip._source = gameObject.AddComponent<AudioSource>();
            soundClip._source.clip = soundClip._clip;
            soundClip._source.volume = soundClip._volume;
            soundClip._source.loop = soundClip._loop;
        }   
    }

    /// <summary>
    /// Plays a sound by its string name.
    /// This string is given to the audio clip from the game object's inspector in which the script is attached to.
    /// </summary>
    /// <param name="soundName"> The sound clip's name. </param>
    public void Play(string soundName)
    {
        Sound chosenSoundClip = Array.Find(_soundClips, soundClip => soundClip._name == soundName);
        chosenSoundClip._source.Play();
    }
}
