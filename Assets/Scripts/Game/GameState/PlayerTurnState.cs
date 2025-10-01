using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class PlayerTurnState : AbstractGameState
{
    public string tableName = "Table";

    public PlayerTurnState(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }

    public int playerNumber
    {
        get; private set;
    }

    public override void StateEnter()
    {
        string trunStatement = 
            new LocalizedString(tableName, "PlayersTurn_1").GetLocalizedString() +
            playerNumber.ToString() +
            new LocalizedString(tableName, "PlayersTurn_2").GetLocalizedString();
        GameManager.Instance.TurnStatementText.text = trunStatement;
    }
}
