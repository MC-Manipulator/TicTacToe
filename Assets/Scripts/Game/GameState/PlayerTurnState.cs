using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : AbstractGameState
{
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

    }
}
