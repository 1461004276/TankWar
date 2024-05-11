using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public static MusicManager Instance
    {
        get => instance;
    }

    public AudioSource musicSource;
    public AudioSource soundSource;

    private void Awake()
    {
        instance = this as MusicManager;
    }

    public void MusicIsPlaying(bool isPlaying)
    {
        musicSource.mute = !isPlaying;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SoundIsPlaying(bool isPlaying)
    {
        soundSource.mute = !isPlaying;
    }

    public void SetSoundVolume(float volume)
    {
        soundSource.volume = volume;
    }
}
