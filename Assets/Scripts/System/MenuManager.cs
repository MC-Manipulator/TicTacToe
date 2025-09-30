using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI Referrence")]
    public GameObject SettingPanel;
    public GameObject GameModeSelectPanel;
    public Slider MasterVolumeSlider;
    public Slider BGMVolumeSlider;
    public Slider SFXVolumeSlider;
    public List<Button> LanguageButtonList;
    public TMP_Dropdown ResolutonDropdown;
    public Toggle FullscreenToggle;

    [Header("Audio Referrence")]
    public List<AudioClip> AudioClips; // 0:select 1:confirm 2:confirm 3:back
    public AudioClip MenuBGM;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(MenuBGM);
    }

    public void OpenGameModeSelectPanel()
    {
        AudioManager.Instance.PlaySound(AudioClips[0]);
        GameModeSelectPanel.SetActive(true);
    }

    public void CloseGameModeSelectPanel()
    {
        AudioManager.Instance.PlaySound(AudioClips[3]);
        GameModeSelectPanel.SetActive(false);
    }

    public void StartGameInHotseatMode()
    {
        AudioManager.Instance.PlaySound(AudioClips[2]);
        GameInfoManager.Instance.CurrentGameInfo.BoardSize = 3;
        GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode = GameMode.Hotseat;
        SceneManager.LoadScene("Game");
    }

    public void StartGameInComputerMode()
    {
        AudioManager.Instance.PlaySound(AudioClips[2]);
        GameInfoManager.Instance.CurrentGameInfo.BoardSize = 3;
        GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode = GameMode.Computer;
        SceneManager.LoadScene("Game");
    }

    public void OpenSettingPanel()
    {
        AudioManager.Instance.PlaySound(AudioClips[0]);
        SettingPanel.SetActive(true);
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

        string resolution = GameSettingManager.Instance.screenWidth + "*" + GameSettingManager.Instance.screenHeight;
        ResolutonDropdown.captionText.text = resolution;

        FullscreenToggle.isOn = GameSettingManager.Instance.isFullScreen;
    }

    public void CloseSettingPanel()
    {
        AudioManager.Instance.PlaySound(AudioClips[3]);
        SettingPanel.SetActive(false);
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
        AudioManager.Instance.PlaySound(AudioClips[1]);
        GameSettingManager.Instance.SetLanguage(button.name.ToString(), true);
    }

    public void SetResolution(TMP_Dropdown dropdown)
    {
        string resolution = dropdown.captionText.text;
        switch (resolution)
        {
            case "1920*1080":
                GameSettingManager.Instance.SetScreenResolution(1920, 1080, true);
                break;
            case "3140*2160":
                GameSettingManager.Instance.SetScreenResolution(3140, 2160, true);
                break;
        }
    }

    public void SetFullScreen(Toggle toggle)
    {
        GameSettingManager.Instance.SetFullScreen(toggle.isOn);
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
