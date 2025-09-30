using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInfo
{
    public int boardSize;

    public List<List<int>> boardDoubleList;

    public BoardInfo(int size)
    {
        boardDoubleList = new List<List<int>>();

        boardSize = size;

        for (int i = 0; i < boardSize; i++)
        {
            List<int> list = new List<int>();
            for (int j = 0; j < boardSize; j++)
            {
                list.Add(0);
            }
            boardDoubleList.Add(list);
        }
    }

    public List<Vector2> GetEmptyCornerBlanks()
    {
        List<Vector2> list = new List<Vector2>();
        if (boardDoubleList[0][0] == 0)
        {
            list.Add(new Vector2(0, 0));
        }
        else if (boardDoubleList[0][boardSize] == 0)
        {
            list.Add(new Vector2(0, boardSize));
        }
        else if (boardDoubleList[boardSize][0] == 0)
        {
            list.Add(new Vector2(boardSize, 0));
        }
        else if (boardDoubleList[boardSize][boardSize] == 0)
        {
            list.Add(new Vector2(boardSize, boardSize));
        }
        return list;
    }

    public List<Vector2> GetEmptyBlanks()
    {
        List<Vector2> list = new List<Vector2>();
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                if (boardDoubleList[i][j] == 0)
                {
                    list.Add(new Vector2(i, j));
                }
            }
        }
        return list;
    }

    public List<Vector2> GetCenterEmptyBlank()
    {
        if (boardSize % 2 == 0)
        {
            List<Vector2> list = new List<Vector2>();
            if (boardDoubleList[boardSize / 2][boardSize / 2] == 0)
                list.Add(new Vector2(boardSize / 2, boardSize / 2));
            return list;
        }
        else
        {
            List<Vector2> list = new List<Vector2>();
            if (boardDoubleList[boardSize / 2][boardSize / 2] == 0)
            {
                list.Add(new Vector2(boardSize / 2, boardSize / 2));
            }
            else if (boardDoubleList[boardSize / 2 - 1][boardSize / 2] == 0)
            {
                list.Add(new Vector2(boardSize / 2 - 1, boardSize / 2));
            }
            else if (boardDoubleList[boardSize / 2 - 1][boardSize / 2 - 1] == 0)
            {
                list.Add(new Vector2(boardSize / 2 - 1, boardSize / 2 - 1));
            }
            else if (boardDoubleList[boardSize / 2][boardSize / 2 - 1] == 0)
            {
                list.Add(new Vector2(boardSize / 2, boardSize / 2 - 1));
            }
            return list;
        }

    }

    public void PlaceChess(int player, int row, int col)
    {
        boardDoubleList[row][col] = player;
    }

    public bool JugdeChessInLine()
    {
        int start = 0;
        bool inLine = false;
        for (int i = 0;i < boardSize;i++)
        {
            if (boardDoubleList[i][0] != 0)
            {
                start = boardDoubleList[i][0];
                for (int j = 0; j < boardSize; j++)
                {
                    if (boardDoubleList[i][j] != start)
                    {
                        break;
                    }
                    if (j == boardSize - 1)
                    {
                        inLine = true;
                    }
                }
            }
        }

        for (int i = 0; i < boardSize; i++)
        {
            if (boardDoubleList[0][i] != 0)
            {
                start = boardDoubleList[0][i];
                for (int j = 0; j < boardSize; j++)
                {
                    if (boardDoubleList[j][i] != start)
                    {
                        break;
                    }
                    if (j == boardSize - 1)
                    {
                        inLine = true;
                    }
                }
            }
        }

        start = boardDoubleList[0][0]; 
        if (boardDoubleList[0][0] != 0)
        {
            for (int i = 0, j = 0; i < boardSize; i++, j++)
            {
                if (boardDoubleList[i][j] != start)
                {
                    break;
                }
                if (j == boardSize - 1)
                {
                    inLine = true;
                }
            }
        }

        start = boardDoubleList[0][boardSize - 1];
        if (boardDoubleList[0][boardSize - 1] != 0)
        {
            for (int i = 0, j = boardSize - 1; i < boardSize; i++, j--)
            {
                if (boardDoubleList[i][j] != start)
                {
                    break;
                }
                if (j == 0)
                {
                    inLine = true;
                }
            }
        }

        return inLine;
    }
}
