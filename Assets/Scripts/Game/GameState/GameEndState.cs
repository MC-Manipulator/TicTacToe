using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : AbstractGameState
{
    private int winnerNumber; //0:平局 1:玩家1获胜 2:玩家2获胜/电脑获胜

    public GameEndState(int winnerNumber)
    {
        this.winnerNumber = winnerNumber;
    }

    public override void StateEnter()
    {
        if (GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode == GameMode.Computer)
        {
            if (winnerNumber == 0)
            {
                Debug.Log("游戏结束，平局");
            }
            else if (winnerNumber == 1)
            {
                Debug.Log("游戏结束，玩家获胜");
            }
            else if (winnerNumber == 2)
            {
                Debug.Log("游戏结束，电脑获胜");
            }
        }
        else
        {
            if (winnerNumber == 0)
            {
                Debug.Log("游戏结束，平局");
            }
            else
            {
                Debug.Log("游戏结束，玩家" + winnerNumber + "获胜");
            }
        }
    }
}
