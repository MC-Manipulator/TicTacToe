using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private List<AudioSource> sfxSources = new List<AudioSource>();

    [Header("Volume Settings")]
    [Range(0, 1)] [SerializeField] private float masterVolume;
    [Range(0, 1)] [SerializeField] private float bgmVolume;
    [Range(0, 1)] [SerializeField] private float sfxVolume;

    public float MasterVolume
    {
        get { return masterVolume; }
        set
        {
            if (value >= 0 && value < 1) masterVolume = value;
            else if (value < 0) masterVolume = 0;
            else masterVolume = 1;

            masterVolume = value;
            BGMVolume = bgmVolume;
            SFXVolume = sfxVolume;
        }
    }

    public float BGMVolume 
    { 
        get { return bgmVolume; }
        set 
        {
            if (value >= 0 && value < 1) bgmVolume = value;
            else if (value < 0) bgmVolume = 0;
            else bgmVolume = 1;

            bgmSource.volume = bgmVolume * masterVolume;
        }
    }

    public float SFXVolume
    {
        get { return sfxVolume; }
        set
        {
            if (value >= 0 && value < 1) sfxVolume = value;
            else if (value < 0) sfxVolume = 0;
            else sfxVolume = 1;
            
            foreach (var source in sfxSources)
            {
                source.volume = sfxVolume * masterVolume;
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeAudioSources();
            LoadVolumeSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudioSources()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();

        foreach (var source in new[] { bgmSource })
        {
            source.loop = true;
            source.volume = 0f;
        }
    }

    public void PlayMusic(AudioClip music)
    {
        bgmSource.clip = music;
        bgmSource.volume = bgmVolume * masterVolume;
        bgmSource.Play();
    }

    public void PlaySound(AudioClip clip, Vector3 position = default)
    {
        AudioSource source = GetAvailableSoundSource();
        source.transform.position = position;
        source.clip = clip;
        source.volume = sfxVolume * masterVolume;
        source.Play();
    }

    private AudioSource GetAvailableSoundSource()
    {
        foreach (var source in sfxSources)
        {
            if (!source.isPlaying) return source;
        }

        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        sfxSources.Add(newSource);
        return newSource;
    }

    public void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("BGMVolume", bgmVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    private void LoadVolumeSettings()
    {
        MasterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        BGMVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }
}
