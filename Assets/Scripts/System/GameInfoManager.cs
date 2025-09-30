using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComputerDifficulty
{
    Eazy,
    Hard
}

public enum GameMode
{
    Hotseat,
    Computer
}

public class GameInfoManager : MonoBehaviour
{
    public static GameInfoManager Instance { get; private set; }

    public GameInfo CurrentGameInfo { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CurrentGameInfo = new GameInfo();
            //TEST
            GameInfoManager.Instance.CurrentGameInfo.BoardSize = 3;
            GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode = GameMode.Hotseat;

            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Save()
    {

    }

    public void Load()
    {

    }
}
