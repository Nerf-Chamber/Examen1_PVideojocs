using System.Collections.Generic;
using UnityEngine;

public enum AudioClips
{
    Rahhh,
    Augh
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    public Dictionary<AudioClips, AudioClip> clipList = new Dictionary<AudioClips, AudioClip> { };
    private void Awake()
    {
        Instance = this;
        clipList.Add(AudioClips.Rahhh, audioClips[0]);
        clipList.Add(AudioClips.Augh, audioClips[1]);
    }
}