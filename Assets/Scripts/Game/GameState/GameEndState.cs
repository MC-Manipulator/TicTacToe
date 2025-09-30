using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : AbstractGameState
{
    private int winnerNumber;

    public GameEndState(int winnerNumber)
    {
        this.winnerNumber = winnerNumber;
    }

    public override void StateEnter()
    {
        if (GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode == GameMode.Computer)
        {
            if (winnerNumber == 1)
            {
                Debug.Log("游戏结束，玩家获胜");
            }
            else
            {
                Debug.Log("游戏结束，电脑获胜");
            }
        }
        else
        {
            Debug.Log("游戏结束，玩家" + winnerNumber + "获胜");
        }
    }
}
