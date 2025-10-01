using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI Referrence")]
    //public GameObject SettingPanel;
    public GameObject GameModeSelectPanel;
    public GameObject DifficultySelectPanel;
    /*
    public Slider MasterVolumeSlider;
    public Slider BGMVolumeSlider;
    public Slider SFXVolumeSlider;
    public List<Button> LanguageButtonList;
    public TMP_Dropdown ResolutonDropdown;
    public Toggle FullscreenToggle;*/
    public Button BackButton;

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
        BackButton.onClick.RemoveAllListeners();
        BackButton.onClick.AddListener(CloseGameModeSelectPanel);
        AudioManager.Instance.PlaySound(AudioClips[0]);
        GameModeSelectPanel.SetActive(true);
    }

    public void CloseGameModeSelectPanel()
    {
        BackButton.onClick.RemoveAllListeners();
        AudioManager.Instance.PlaySound(AudioClips[3]);
        GameModeSelectPanel.SetActive(false);
    }

    public void OpenDifficultySelectPanel()
    {
        BackButton.onClick.RemoveAllListeners();
        BackButton.onClick.AddListener(CloseDifficultySelectPanel);
        AudioManager.Instance.PlaySound(AudioClips[0]);
        DifficultySelectPanel.SetActive(true);
    }

    public void CloseDifficultySelectPanel()
    {
        BackButton.onClick.RemoveAllListeners();
        BackButton.onClick.AddListener(CloseGameModeSelectPanel);
        AudioManager.Instance.PlaySound(AudioClips[3]);
        DifficultySelectPanel.SetActive(false);
    }

    public void StartGameInHotseatMode()
    {
        AudioManager.Instance.PlaySound(AudioClips[2]);
        GameInfoManager.Instance.CurrentGameInfo.BoardSize = 3;
        GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode = GameMode.Hotseat;
        SceneManager.LoadScene("Game");
    }

    public void StartGameInComputerMode(int difficulty)
    {
        AudioManager.Instance.PlaySound(AudioClips[2]);
        
        GameInfoManager.Instance.CurrentGameInfo.BoardSize = 3;
        GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode = GameMode.Computer;
        if (difficulty == 1)
        {
            GameInfoManager.Instance.CurrentGameInfo.CurrentDifficulty = ComputerDifficulty.Eazy;
        }
        else if (difficulty == 2)
        {
            GameInfoManager.Instance.CurrentGameInfo.CurrentDifficulty = ComputerDifficulty.Hard;
        }
        SceneManager.LoadScene("Game");
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
