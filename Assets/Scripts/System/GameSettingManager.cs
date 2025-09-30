using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLanguage
{
    Chinese,
    English
}

public class GameSettingManager : MonoBehaviour
{
    public static GameSettingManager Instance { get; private set; }
    public GameLanguage currentLanguage { get; private set; }

    public bool isFullScreen { get; private set; }

    public int screenWidth { get; private set; }
    public int screenHeight { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLanguage(string language, bool save)
    {
        switch (language)
        {
            case "Chinese":
                currentLanguage = GameLanguage.Chinese;
                break;
            case "English":
                currentLanguage = GameLanguage.English;
                break;
        }

        if (save)
            SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetString("Language", currentLanguage.ToString());

        PlayerPrefs.SetInt("ScreenWidth", screenWidth);
        PlayerPrefs.SetInt("ScreenHeight", screenHeight);
    }

    private void LoadSettings()
    {
        SetLanguage(PlayerPrefs.GetString("Language", "English"), false);
        SetScreenResolution(
            PlayerPrefs.GetInt("ScreenWidth", 1920), 
            PlayerPrefs.GetInt("ScreenHeight", 1080), 
            false);
    }

    public void SetScreenResolution(int width, int height, bool save)
    {
        screenWidth = width;
        screenHeight = height;

        if (isFullScreen)
            Screen.SetResolution(screenWidth, screenHeight, true);
        else
            Screen.SetResolution(screenWidth, screenHeight, false);

        if (save)
            SaveSettings();
    }

    public void SetFullScreen(bool full)
    {
        isFullScreen = full;
        Screen.fullScreen = full;
    }
}
