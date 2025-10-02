using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController
{
    private GameManager gameManager;

    public AbstractGameState CurrentGameState { get; private set; }

    public StateController(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void ChangeState(AbstractGameState state, bool delay)
    {
        if (CurrentGameState != null)
        {
            CurrentGameState.StateExit();
        }

        if (delay)
        {
            gameManager.StartCoroutine(DelayExit(state));
        }
        else
        {
            CurrentGameState = state;
            CurrentGameState.StateEnter();
        }
    }

    private IEnumerator DelayExit(AbstractGameState state)
    {
        yield return new WaitForSeconds(0.5f);
        CurrentGameState = state;
        CurrentGameState.StateEnter();
    }
}
