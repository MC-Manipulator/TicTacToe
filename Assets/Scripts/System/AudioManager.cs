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

    [Header("Audio Referrence")]
    [SerializeField] private List<AudioClip> SFXClips; // 0:select 1:switch 2:confirm 3:back
    [SerializeField] private List<AudioClip> BgmClips; // 0:menu 1:game

    private List<AudioResource> SFXResources; // 0:select 1:switch 2:confirm 3:back
    private List<AudioResource> BgmResources; // 0:menu 1:game

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

    private class AudioResource
    {
        public string name { get; private set; }
        public AudioClip clip { get; private set; }

        public AudioResource(string name, AudioClip clip)
        {
            this.name = name;
            this.clip = clip;
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
            LoadAudioResources();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadAudioResources()
    {
        SFXResources = new List<AudioResource>();
        SFXResources.Add(new AudioResource("select", SFXClips[0]));
        SFXResources.Add(new AudioResource("switch", SFXClips[1]));
        SFXResources.Add(new AudioResource("confirm", SFXClips[2]));
        SFXResources.Add(new AudioResource("back", SFXClips[3]));

        BgmResources = new List<AudioResource>();
        BgmResources.Add(new AudioResource("menu", BgmClips[0]));
        BgmResources.Add(new AudioResource("game", BgmClips[1]));
    }

    public void PlaySFX(string name)
    {
        PlaySound(SFXResources.Find((AudioResource a) =>
        {
            return a.name == name;
        }).clip);
    }

    public void PlayBGM(string name)
    {
        PlayMusic(BgmResources.Find((AudioResource a) =>
        {
            return a.name == name;
        }).clip);
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

    private void PlayMusic(AudioClip music)
    {
        bgmSource.clip = music;
        bgmSource.volume = bgmVolume * masterVolume;
        bgmSource.Play();
    }

    private void PlaySound(AudioClip clip, Vector3 position = default)
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
