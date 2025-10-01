using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class GameEndState : AbstractGameState
{
    private int winnerNumber; //0:ƽ�� 1:���1��ʤ 2:���2��ʤ/���Ի�ʤ
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
                Debug.Log("��Ϸ������ƽ��");
            }
            else if (winnerNumber == 1)
            {
                endPanelTitle = playerWinString;
                Debug.Log("��Ϸ��������һ�ʤ");
            }
            else if (winnerNumber == 2)
            {
                endPanelTitle = computerWinString;
                Debug.Log("��Ϸ���������Ի�ʤ");
            }
        }
        else
        {
            if (winnerNumber == 0)
            {
                endPanelTitle = drawString;
                Debug.Log("��Ϸ������ƽ��");
            }
            else
            {
                endPanelTitle = playerWinString1 + winnerNumber + playerWinString2;
                Debug.Log("��Ϸ���������" + winnerNumber + "��ʤ");
            }
        }
        GameManager.Instance.OpenEndPanel(endPanelTitle);
    }
}
