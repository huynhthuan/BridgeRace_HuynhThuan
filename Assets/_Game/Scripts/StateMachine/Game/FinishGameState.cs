using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameState : IStateGame
{
    public void OnEnter(GameManager gameManger)
    {


    }

    public void OnExecute(GameManager gameManger)
    {
        gameManger.enableJoystick = false;
        gameManger.isPlayGame = false;
    }

    public void OnExit(GameManager gameManger) { }
}
