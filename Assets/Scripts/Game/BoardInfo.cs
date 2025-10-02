using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public List<Vector2> GetRowNearlyALineBlank(int playerNumber)
    {
        List<Vector2> list = new List<Vector2>();

        int mostCount = 0;
        int row = 0;

        for (int i = 0; i < boardSize; i++)
        {
            int count = 0;
            int blank = 0;
            for (int j = 0; j < boardSize; j++)
            {
                if (boardDoubleList[i][j] == playerNumber)
                {
                    count++;
                }
                if (boardDoubleList[i][j] == 0)
                {
                    blank++;
                }
            }
            if (count > mostCount && blank != 0)
            {
                mostCount = count;
                row = i;
            }
        }

        for (int j = 0; j < boardSize; j++)
        {
            if (boardDoubleList[row][j] == 0)
            {
                list.Add(new Vector2(row, j));
            }
        }

        return list;
    }

    public int GetRowNearlyALineCount(int playerNumber)
    {
        List<Vector2> list = new List<Vector2>();

        int mostCount = 0;
        int row = 0;

        for (int i = 0; i < boardSize; i++)
        {
            int count = 0;
            int blank = 0;
            for (int j = 0; j < boardSize; j++)
            {
                if (boardDoubleList[i][j] == playerNumber)
                {
                    count++;
                }
                if (boardDoubleList[i][j] == 0)
                {
                    blank++;
                }
            }
            if (count > mostCount && blank != 0)
            {
                mostCount = count;
                row = i;
            }
        }

        for (int j = 0; j < boardSize; j++)
        {
            if (boardDoubleList[row][j] == playerNumber)
            {
                list.Add(new Vector2(row, j));
            }
        }

        return list.Count;
    }

    public List<Vector2> GetColNearlyALineBlank(int playerNumber)
    {
        List<Vector2> list = new List<Vector2>();

        int mostCount = 0;
        int col = 0;

        for (int i = 0; i < boardSize; i++)
        {
            int count = 0;
            int blank = 0;
            for (int j = 0; j < boardSize; j++)
            {
                if (boardDoubleList[j][i] == playerNumber)
                {
                    count++;
                }
                if (boardDoubleList[j][i] == 0)
                {
                    blank++;
                }
            }
            if (count > mostCount && blank != 0)
            {
                mostCount = count;
                col = i;
            }
        }

        for (int i = 0; i < boardSize; i++)
        {
            if (boardDoubleList[i][col] == 0)
            {
                list.Add(new Vector2(i, col));
            }
        }

        return list;
    }
    public int GetColNearlyALineCount(int playerNumber)
    {
        List<Vector2> list = new List<Vector2>();

        int mostCount = 0;
        int col = 0;

        for (int i = 0; i < boardSize; i++)
        {
            int count = 0;
            int blank = 0;
            for (int j = 0; j < boardSize; j++)
            {
                if (boardDoubleList[j][i] == playerNumber)
                {
                    count++;
                }
                if (boardDoubleList[j][i] == 0)
                {
                    blank++;
                }
            }
            if (count > mostCount && blank != 0)
            {
                mostCount = count;
                col = i;
            }
        }

        for (int i = 0; i < boardSize; i++)
        {
            if (boardDoubleList[i][col] == playerNumber)
            {
                list.Add(new Vector2(i, col));
            }
        }

        return list.Count;
    }

    public List<Vector2> GetDiaNearlyALineBlank(int playerNumber)
    {
        List<Vector2> list = new List<Vector2>();

        int mostCount = 0;
        int diagonal = 0;

        int count = 0;
        int blank = 0;
        for (int i = 0; i < boardSize; i++)
        {
            if (boardDoubleList[i][i] == playerNumber)
            {
                count++;
            }
            if (boardDoubleList[i][i] == 0)
            {
                blank++;
            }
        }
        if (count > mostCount && blank != 0)
        {
            mostCount = count;
            diagonal = 1;
        }

        count = 0;
        blank = 0;
        for (int i = 0; i < boardSize; i++)
        {
            if (boardDoubleList[boardSize - i - 1][i] == playerNumber)
            {
                count++;
            }
            if (boardDoubleList[boardSize - i - 1][i] == 0)
            {
                blank++;
            }
        }
        if (count > mostCount && blank != 0)
        {
            mostCount = count;
            diagonal = -1;
        }

        if (diagonal == 1)
        {

            for (int i = 0; i < boardSize; i++)
            {
                if (boardDoubleList[i][i] == 0)
                {
                    list.Add(new Vector2(i, i));
                }
            }
        }
        else
        {
            for (int i = 0; i < boardSize; i++)
            {
                if (boardDoubleList[i][boardSize - i - 1] == 0)
                {
                    list.Add(new Vector2(i, boardSize - i - 1));
                }
            }
        }


        return list;
    }

    public int GetDiaNearlyALineCount(int playerNumber)
    {
        List<Vector2> list = new List<Vector2>();

        int mostCount = 0;
        int diagonal = 0;

        int count = 0;
        int blank = 0;
        for (int i = 0; i < boardSize; i++)
        {
            if (boardDoubleList[i][i] == playerNumber)
            {
                count++;
            }
            if (boardDoubleList[i][i] == 0)
            {
                blank++;
            }
        }
        if (count > mostCount && blank != 0)
        {
            mostCount = count;
            diagonal = 1;
        }

        count = 0;
        blank = 0;
        for (int i = 0; i < boardSize; i++)
        {
            if (boardDoubleList[boardSize - i - 1][i] == playerNumber)
            {
                count++;
            }
            else if (boardDoubleList[boardSize - i - 1][i] == 0)
            {
                blank++;
            }
        }
        if (count > mostCount && blank != 0)
        {
            mostCount = count;
            diagonal = -1;
        }

        if (diagonal == 1)
        {

            for (int i = 0; i < boardSize; i++)
            {
                if (boardDoubleList[i][i] == playerNumber)
                {
                    list.Add(new Vector2(i, i));
                }
            }
        }
        else
        {
            for (int i = 0; i < boardSize; i++)
            {
                if (boardDoubleList[i][boardSize - i - 1] == playerNumber)
                {
                    list.Add(new Vector2(i, boardSize - i - 1));
                }
            }
        }


        return list.Count;
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

    public bool IsFull()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                if (boardDoubleList[i][j] == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
