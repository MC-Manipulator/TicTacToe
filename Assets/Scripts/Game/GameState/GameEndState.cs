using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class GameEndState : AbstractGameState
{
    private int winnerNumber; //0:平局 1:玩家1获胜 2:玩家2获胜/电脑获胜
    private string drawString;
    private string playerWinString;
    private string computerWinString;
    private string playerWinString1;
    private string playerWinString2;

    public string tableName = "Table";

    public GameEndState(int winnerNumber)
    {
        this.winnerNumber = winnerNumber;

        drawString = new LocalizedString(tableName, "Draw").GetLocalizedString();
        playerWinString = new LocalizedString(tableName, "ComputerMode_PlayerWin").GetLocalizedString();
        computerWinString = new LocalizedString(tableName, "ComputerMode_ComputerWin").GetLocalizedString();
        playerWinString1 = new LocalizedString(tableName, "HotseatMode_Win1").GetLocalizedString();
        playerWinString2 = new LocalizedString(tableName, "HotseatMode_Win2").GetLocalizedString();
    }

    public override void StateEnter()
    {
        string trunStatement = "";
        GameManager.Instance.TurnStatementText.text = trunStatement;

        string endPanelTitle = "";
        if (GameInfoManager.Instance.CurrentGameInfo.CurrentGameMode == GameMode.Computer)
        {
            if (winnerNumber == 0)
            {
                endPanelTitle = drawString;
                Debug.Log("游戏结束，平局");
            }
            else if (winnerNumber == 1)
            {
                endPanelTitle = playerWinString;
                Debug.Log("游戏结束，玩家获胜");
            }
            else if (winnerNumber == 2)
            {
                endPanelTitle = computerWinString;
                Debug.Log("游戏结束，电脑获胜");
            }
        }
        else
        {
            if (winnerNumber == 0)
            {
                endPanelTitle = drawString;
                Debug.Log("游戏结束，平局");
            }
            else
            {
                endPanelTitle = playerWinString1 + winnerNumber + playerWinString2;
                Debug.Log("游戏结束，玩家" + winnerNumber + "获胜");
            }
        }
        GameManager.Instance.OpenEndPanel(endPanelTitle);
    }
}
