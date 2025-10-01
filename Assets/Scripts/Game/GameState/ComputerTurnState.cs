using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class ComputerTurnState : AbstractGameState
{
    public string tableName = "Table";

    public override void StateEnter()
    {
        string trunStatement =
            new LocalizedString(tableName, "ComputerTurn").GetLocalizedString();
        GameManager.Instance.TurnStatementText.text = trunStatement;

        Vector2 selectBlank = new Vector2();
        if (GameInfoManager.Instance.CurrentGameInfo.CurrentDifficulty == ComputerDifficulty.Eazy)
        {
            //�򵥵��Դ����пɷ������ӵĸ��������ѡ��
            List<Vector2> list = GameManager.Instance.BoardInfo.GetEmptyBlanks();
            selectBlank = list[Random.Range(0, list.Count)];
        }
        else if (GameInfoManager.Instance.CurrentGameInfo.CurrentDifficulty == ComputerDifficulty.Hard)
        {
            //���ѵ��Ի�������ɼ������Ͻ�Ҫ���һ���ߵ��С��С��Խ���
            //��ֹ��ҳ��Ͻ�Ҫ���һ���ߵ��С��С��Խ���
            //ѡ������
            List<Vector2> centerlist = GameManager.Instance.BoardInfo.GetCenterEmptyBlank();
            selectBlank = centerlist[Random.Range(0, centerlist.Count)];
            //ѡ�������λ�߽�
            List<Vector2> cornerlist = GameManager.Instance.BoardInfo.GetEmptyCornerBlanks();
            selectBlank = cornerlist[Random.Range(0, cornerlist.Count)];
            //���
            List<Vector2> emptylist = GameManager.Instance.BoardInfo.GetEmptyBlanks();
            selectBlank = emptylist[Random.Range(0, emptylist.Count)];
        }
        GameManager.Instance.ComputerPlaceChess((int)selectBlank.x, (int)selectBlank.y);
    }
}
