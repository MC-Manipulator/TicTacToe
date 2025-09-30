using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blank : MonoBehaviour
{
    private int row;
    public int Row
    {
        get
        {
            return row;
        }
        set
        {
            if (row < 0)
            {
                row = 0;
            }
            else if (row >= GameInfoManager.Instance.CurrentGameInfo.BoardSize)
            {
                row = GameInfoManager.Instance.CurrentGameInfo.BoardSize;
            }
            row = value;
        }
    }

    private int col;
    public int Col
    {
        get
        {
            return col;
        }
        set
        {
            if (col < 0)
            {
                col = 0;
            }
            else if (col >= GameInfoManager.Instance.CurrentGameInfo.BoardSize)
            {
                col = GameInfoManager.Instance.CurrentGameInfo.BoardSize;
            }
            col = value;
        }
    }

    private int playerChessPlaced;
    public int PlayerChessPlaced
    {
        get
        {
            return playerChessPlaced;
        }
        set
        {
            if (playerChessPlaced == 0 && value != 0)
            {
                playerChessPlaced = value;
                ChangeBlankColor();
            }
        }
    }

    private void Awake()
    {
        playerChessPlaced = 0;
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.Controller.CurrentGameState is PlayerTurnState && playerChessPlaced == 0)
        {
            PlayerChessPlaced = ((PlayerTurnState)GameManager.Instance.Controller.CurrentGameState).playerNumber;
            GameManager.Instance.PlayerPlaceChess(row, col);
        }
    }

    private void ChangeBlankColor()
    {
        if (playerChessPlaced == 1)
        {
            gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr);
            sr.color = Color.blue;
        }
        else if (playerChessPlaced == 2)
        {
            gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr);
            sr.color = Color.red;
        }
    }
}
