using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : AbstractGameState
{
    public override void StateEnter()
    {
        GameManager.Instance.BoardInfo = new BoardInfo(GameInfoManager.Instance.CurrentGameInfo.BoardSize);
        GameManager.Instance.GenerateNewBoard();

        if (GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode == GameMode.Computer)
        {
            if (Random.Range(0, 1) == 0)
            {
                GameManager.Instance.Controller.ChangeState(new PlayerTurnState(1), true);
            }
            else
            {
                GameManager.Instance.Controller.ChangeState(new ComputerTurnState(), true);
            }
        }
        else
        {
            GameManager.Instance.Controller.ChangeState(new PlayerTurnState(Random.Range(1, 2)), true);
        }
    }
}
