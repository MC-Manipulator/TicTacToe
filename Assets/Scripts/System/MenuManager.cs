using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI Referrence")]
    public GameObject settingPanel;
    public Slider MasterVolumeSlider;
    public Slider BGMVolumeSlider;
    public Slider SFXVolumeSlider;
    public List<Button> LanguageButtonList;

    [Header("Audio Referrence")]
    public List<AudioClip> audioClips;
    public AudioClip MenuBGM;


    public void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(MenuBGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        AudioManager.Instance.PlaySound(audioClips[0]);
        SceneManager.LoadScene("Game");
    }

    public void OpenSettingPanel()
    {
        AudioManager.Instance.PlaySound(audioClips[0]);
        settingPanel.SetActive(true);
        MasterVolumeSlider.value = AudioManager.Instance.MasterVolume;
        BGMVolumeSlider.value = AudioManager.Instance.BGMVolume;
        SFXVolumeSlider.value = AudioManager.Instance.SFXVolume;

        foreach (var button in LanguageButtonList)
        {
            if (button.name == GameSettingManager.Instance.currentLanguage.ToString())
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }

    }

    public void CloseSettingPanel()
    {
        AudioManager.Instance.PlaySound(audioClips[0]);
        settingPanel.SetActive(false);
    }

    public void SetMasterVolume(Slider slider)
    {
        AudioManager.Instance.MasterVolume = slider.value;
        AudioManager.Instance.SaveVolumeSettings();
    }

    public void SetBGMVolume(Slider slider)
    {
        AudioManager.Instance.BGMVolume = slider.value;
        AudioManager.Instance.SaveVolumeSettings();
    }

    public void SetSFXVolume(Slider slider)
    {
        AudioManager.Instance.SFXVolume = slider.value;
        AudioManager.Instance.SaveVolumeSettings();
    }

    public void SetLanguage(Button button)
    {
        foreach (var b in LanguageButtonList)
        {
            if (!b.name.Equals(button.name))
            {
                b.interactable = true;
            }
        }
        button.interactable = false;
        AudioManager.Instance.PlaySound(audioClips[1]);
        GameSettingManager.Instance.SetLanguage(button.name.ToString());
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
