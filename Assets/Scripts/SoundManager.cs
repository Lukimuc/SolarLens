using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource m_AudioSource;
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
        soundMuted = true;
    }

    public void unmuteSound()
    {
        soundMuted = false;
    }

    public void playSound()
    {

    }
}

public enum sounds
{
    ca
}
