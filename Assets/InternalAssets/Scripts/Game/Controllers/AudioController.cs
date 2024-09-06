using System.Collections;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{

    public AudioSource soundsSource;

    bool muteSounds = false;

    protected override void Awake()
    {
        base.Awake();

        muteSounds = PlayerPrefs.GetInt("MuteSounds", 0) == 1;
        soundsSource.mute = muteSounds;
    }

    public bool SoundsMuted()
    {
        return muteSounds;
    }

    public void SetSoundsMuteValue(bool v)
    {
        muteSounds = v;
        soundsSource.mute = v;
        PlayerPrefs.SetInt("MuteSounds", v ? 1 : 0);
    }
}