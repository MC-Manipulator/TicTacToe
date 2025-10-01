using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : AbstractGameState
{
    private int winnerNumber; //0:ƽ�� 1:���1��ʤ 2:���2��ʤ/���Ի�ʤ

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
                Debug.Log("��Ϸ������ƽ��");
            }
            else if (winnerNumber == 1)
            {
                Debug.Log("��Ϸ��������һ�ʤ");
            }
            else if (winnerNumber == 2)
            {
                Debug.Log("��Ϸ���������Ի�ʤ");
            }
        }
        else
        {
            if (winnerNumber == 0)
            {
                Debug.Log("��Ϸ������ƽ��");
            }
            else
            {
                Debug.Log("��Ϸ���������" + winnerNumber + "��ʤ");
            }
        }
    }
}
