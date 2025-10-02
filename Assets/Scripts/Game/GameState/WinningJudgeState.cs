using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningJudgeState : AbstractGameState
{
    private int currentPlayerNumber;

    public WinningJudgeState(int currentPlayerNumber)
    {
        this.currentPlayerNumber = currentPlayerNumber;
    }

    public override void StateEnter()
    {
        if (GameManager.Instance.BoardInfo.JugdeChessInLine())
        {
            GameManager.Instance.Controller.ChangeState(new GameEndState(currentPlayerNumber), false);
            return;
        }
        else
        {
            if (GameManager.Instance.BoardInfo.IsFull())
            {
                GameManager.Instance.Controller.ChangeState(new GameEndState(0), false);
                return;
            }

            if (GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode == GameMode.Computer)
            {
                if (currentPlayerNumber == 1)
                {
                    GameManager.Instance.Controller.ChangeState(new ComputerTurnState(), false);
                }
                else
                {
                    GameManager.Instance.Controller.ChangeState(new PlayerTurnState(1), false);
                }
            }
            else
            {
                if (currentPlayerNumber == 2)
                {
                    GameManager.Instance.Controller.ChangeState(new PlayerTurnState(1), false);
                }
                else
                {
                    GameManager.Instance.Controller.ChangeState(new PlayerTurnState(2), false);
                }
            }
        }

    }
}
