using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo
{
    private int boardSize;
    public int BoardSize
    {
        get
        {
            return boardSize;
        }
        set
        {
            if (value > 5)
            {
                value = 5;
            }
            else if (value < 3)
            {
                value = 3;
            }

            boardSize = value;
        }
    }

    private GameMode currentGameMode;
    public GameMode CurrentGameMode
    {
        get
        {
            return currentGameMode;
        }
        set
        {
            currentGameMode = value;
        }
    }

    private ComputerDifficulty currentDifficulty;
    public ComputerDifficulty CurrentDifficulty
    {
        get
        {
            return currentDifficulty;
        }
        set
        {
            CurrentDifficulty = value;
        }
    }

    public PlayerInfo PlayerInfo;
}
