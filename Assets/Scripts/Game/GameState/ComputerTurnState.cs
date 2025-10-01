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
            //简单电脑从所有可放置棋子的格子中随机选择
            List<Vector2> list = GameManager.Instance.BoardInfo.GetEmptyBlanks();
            selectBlank = list[Random.Range(0, list.Count)];
        }
        else if (GameInfoManager.Instance.CurrentGameInfo.CurrentDifficulty == ComputerDifficulty.Hard)
        {
            //困难电脑会优先完成己方场上将要组成一条线的行、列、对角线
            //阻止玩家场上将要组成一条线的行、列、对角线
            //选择中心
            List<Vector2> centerlist = GameManager.Instance.BoardInfo.GetCenterEmptyBlank();
            selectBlank = centerlist[Random.Range(0, centerlist.Count)];
            //选择随机空位边角
            List<Vector2> cornerlist = GameManager.Instance.BoardInfo.GetEmptyCornerBlanks();
            selectBlank = cornerlist[Random.Range(0, cornerlist.Count)];
            //随机
            List<Vector2> emptylist = GameManager.Instance.BoardInfo.GetEmptyBlanks();
            selectBlank = emptylist[Random.Range(0, emptylist.Count)];
        }
        GameManager.Instance.ComputerPlaceChess((int)selectBlank.x, (int)selectBlank.y);
    }
}
