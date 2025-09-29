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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadLanguageSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLanguage(string language)
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

        SaveLanguageSettings();
    }

    public void SaveLanguageSettings()
    {
        PlayerPrefs.SetString("Language", currentLanguage.ToString());
    }

    private void LoadLanguageSettings()
    {
        SetLanguage(PlayerPrefs.GetString("Language", "English"));
    }
}
