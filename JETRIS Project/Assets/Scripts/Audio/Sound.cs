using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string _name;
    public AudioClip _clip;
    [Range(0f, 1f)] public float _volume;
    public bool _loop;
    [HideInInspector] public AudioSource _source;
}
