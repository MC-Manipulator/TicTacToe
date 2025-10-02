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
    public Button BackButton;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM("menu");
    }

    public void OpenGameModeSelectPanel()
    {
        BackButton.onClick.RemoveAllListeners();
        BackButton.onClick.AddListener(CloseGameModeSelectPanel);
        AudioManager.Instance.PlaySFX("select");
        GameModeSelectPanel.SetActive(true);
    }

    public void CloseGameModeSelectPanel()
    {
        BackButton.onClick.RemoveAllListeners();
        AudioManager.Instance.PlaySFX("back");
        GameModeSelectPanel.SetActive(false);
    }

    public void OpenDifficultySelectPanel()
    {
        BackButton.onClick.RemoveAllListeners();
        BackButton.onClick.AddListener(CloseDifficultySelectPanel);
        AudioManager.Instance.PlaySFX("select");
        DifficultySelectPanel.SetActive(true);
    }

    public void CloseDifficultySelectPanel()
    {
        BackButton.onClick.RemoveAllListeners();
        BackButton.onClick.AddListener(CloseGameModeSelectPanel);
        AudioManager.Instance.PlaySFX("back");
        DifficultySelectPanel.SetActive(false);
    }

    public void StartGameInHotseatMode()
    {
        AudioManager.Instance.PlaySFX("confirm");
        GameInfoManager.Instance.CurrentGameInfo.BoardSize = 3;
        GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode = GameMode.Hotseat;
        SceneManager.LoadScene("Game");
    }

    public void StartGameInComputerMode(int difficulty)
    {
        AudioManager.Instance.PlaySFX("confirm");

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
