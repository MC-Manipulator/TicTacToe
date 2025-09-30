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
                Debug.Log("��Ϸ��������һ�ʤ");
            }
            else
            {
                Debug.Log("��Ϸ���������Ի�ʤ");
            }
        }
        else
        {
            Debug.Log("��Ϸ���������" + winnerNumber + "��ʤ");
        }
    }
}
