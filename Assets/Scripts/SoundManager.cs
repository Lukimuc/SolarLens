using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips;

    private Dictionary<string, AudioClip> soundDictionary;

    public bool soundMuted = false;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        initSoundDictionary();
    }


    // This method was created by Microsoft Copilot
    private void initSoundDictionary()
    {
        soundDictionary = new Dictionary<string, AudioClip>();

        foreach (var clip in audioClips)
        {
            soundDictionary[clip.name] = clip;
        }
    }

    public void muteSound()
    {
        if(!soundMuted)
        {
            soundMuted = true;
            audioSource.mute = true;
            audioSource.Pause();
        } else
        {
            soundMuted = false;
            audioSource.mute = false;
            audioSource.Play();
        }
    }


    // The generation of this method was helped by Microsoft Copilot
    public void playSound(string soundName)
    {
        audioSource.Stop();
        if (soundDictionary.ContainsKey(soundName))
        {
            audioSource.clip = soundDictionary[soundName];
            audioSource.Play();
        }
        else
        {
            Debug.Log("Sound not found: " + soundName);
        }
    }

    public void stopSound()
    {
        audioSource?.Stop();
    }
}
