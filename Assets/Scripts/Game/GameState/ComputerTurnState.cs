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
            //简单电脑
            //从所有可放置棋子的格子中随机选择
            List<Vector2> list = GameManager.Instance.BoardInfo.GetEmptyBlanks();
            selectBlank = list[Random.Range(0, list.Count)];
        }
        else if (GameInfoManager.Instance.CurrentGameInfo.CurrentDifficulty == ComputerDifficulty.Hard)
        {
            //困难电脑
            //策略优先级顺序从下往上

            List<Vector2> rowNearlyALinelist_player = GameManager.Instance.BoardInfo.GetRowNearlyALineBlank(1);
            List<Vector2> colNearlyALinelist_player = GameManager.Instance.BoardInfo.GetColNearlyALineBlank(1);
            List<Vector2> diaNearlyALinelist_player = GameManager.Instance.BoardInfo.GetDiaNearlyALineBlank(1);

            List<Vector2> rowNearlyALinelist = GameManager.Instance.BoardInfo.GetRowNearlyALineBlank(2);
            List<Vector2> colNearlyALinelist = GameManager.Instance.BoardInfo.GetColNearlyALineBlank(2);
            List<Vector2> diaNearlyALinelist = GameManager.Instance.BoardInfo.GetDiaNearlyALineBlank(2);


            int rowNearlyALinelistCount_player = GameManager.Instance.BoardInfo.GetRowNearlyALineCount(1);
            int colNearlyALinelistCount_player = GameManager.Instance.BoardInfo.GetColNearlyALineCount(1);
            int diaNearlyALinelistCount_player = GameManager.Instance.BoardInfo.GetDiaNearlyALineCount(1);

            int rowNearlyALinelistCount = GameManager.Instance.BoardInfo.GetRowNearlyALineCount(2);
            int colNearlyALinelistCount = GameManager.Instance.BoardInfo.GetColNearlyALineCount(2);
            int diaNearlyALinelistCount = GameManager.Instance.BoardInfo.GetDiaNearlyALineCount(2);

            List<Vector2> emptylist = GameManager.Instance.BoardInfo.GetEmptyBlanks();

            string print = "row:";
            foreach (var b in rowNearlyALinelist_player)
            {
                print += " ";
                print += b.ToString();
            }
            print += rowNearlyALinelistCount_player.ToString();
            Debug.Log(print);

            print = "col:";
            foreach (var b in colNearlyALinelist_player)
            {
                print += " ";
                print += b.ToString();
            }
            print += colNearlyALinelistCount_player.ToString();
            Debug.Log(print);

            print = "dia:";
            foreach (var b in diaNearlyALinelist_player)
            {
                print += " ";
                print += b.ToString();
            }
            print += diaNearlyALinelistCount_player.ToString();
            Debug.Log(print);
            //随机
            //selectBlank = emptylist[Random.Range(0, emptylist.Count)];

            /*
            //选择中心
            List <Vector2> centerlist = GameManager.Instance.BoardInfo.GetCenterEmptyBlank();
            selectBlank = centerlist[Random.Range(0, centerlist.Count)];


            //选择随机空位边角
            List<Vector2> cornerlist = GameManager.Instance.BoardInfo.GetEmptyCornerBlanks();
            selectBlank = cornerlist[Random.Range(0, cornerlist.Count)];*/


            //尽量选择价值最高的位置
            List<Vector3> highValue = new List<Vector3>();
            foreach (var v2 in colNearlyALinelist)
            {

                if (highValue.Exists((Vector3 v3) =>
                {
                    if (v3.x == v2.x && v3.y == v2.y)
                    {
                        return true;
                    }
                    return false;
                }))
                {
                    Vector3 find = highValue.Find((Vector3 v3) =>
                    {
                        if (v3.x == v2.x && v3.y == v2.y)
                        {
                            return true;
                        }
                        return false;
                    });
                    find.z = find.z + 1;
                }
                else
                {
                    highValue.Add(v2);
                }
            }


            foreach (var v2 in rowNearlyALinelist)
            {

                if (highValue.Exists((Vector3 v3) =>
                {
                    if (v3.x == v2.x && v3.y == v2.y)
                    {
                        return true;
                    }
                    return false;
                }))
                {
                    Vector3 find = highValue.Find((Vector3 v3) =>
                    {
                        if (v3.x == v2.x && v3.y == v2.y)
                        {
                            return true;
                        }
                        return false;
                    });
                    find.z = find.z + 1;
                }
                else
                {
                    highValue.Add(v2);
                }
            }


            foreach (var v2 in diaNearlyALinelist)
            {

                if (highValue.Exists((Vector3 v3) =>
                {
                    if (v3.x == v2.x && v3.y == v2.y)
                    {
                        return true;
                    }
                    return false;
                }))
                {
                    Vector3 find = highValue.Find((Vector3 v3) =>
                    {
                        if (v3.x == v2.x && v3.y == v2.y)
                        {
                            return true;
                        }
                        return false;
                    });
                    find.z = find.z + 1;
                }
                else
                {
                    highValue.Add(v2);
                }
            }

            highValue.Sort((Vector3 v1, Vector3 v2) =>
            {
                return v1.z > v2.z ? 1 : -1;
            });

            selectBlank = (Vector2)highValue[0];

            //阻止玩家场上将要组成一条线的行、列、对角线

            if (rowNearlyALinelist_player.Count == 1 &&
                rowNearlyALinelistCount_player == GameManager.Instance.BoardInfo.boardSize - 1)
            {
                selectBlank = rowNearlyALinelist_player[0];
            }
            else if (colNearlyALinelist_player.Count == 1 &&
                colNearlyALinelistCount_player == GameManager.Instance.BoardInfo.boardSize - 1)
            {
                selectBlank = colNearlyALinelist_player[0];
            }
            else if (diaNearlyALinelist_player.Count == 1 &&
                diaNearlyALinelistCount_player == GameManager.Instance.BoardInfo.boardSize - 1)
            {
                selectBlank = diaNearlyALinelist_player[0];
            }

            //会优先完成场上己方将要组成一条线的行、列、对角线上的棋子

            if (rowNearlyALinelist.Count == 1 &&
                rowNearlyALinelistCount == GameManager.Instance.BoardInfo.boardSize - 1)
            {
                selectBlank = rowNearlyALinelist[0];
            }
            else if (colNearlyALinelist.Count == 1 &&
                colNearlyALinelistCount == GameManager.Instance.BoardInfo.boardSize - 1)
            {
                selectBlank = colNearlyALinelist[0];
            }
            else if (diaNearlyALinelist.Count == 1 &&
                diaNearlyALinelistCount == GameManager.Instance.BoardInfo.boardSize - 1)
            {
                selectBlank = diaNearlyALinelist[0];
            }
        }

        GameManager.Instance.StartCoroutine(DelayPlaceChess(selectBlank));
    }

    public IEnumerator DelayPlaceChess(Vector2 selectBlank)
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.ComputerPlaceChess((int)selectBlank.x, (int)selectBlank.y);
    }
}
