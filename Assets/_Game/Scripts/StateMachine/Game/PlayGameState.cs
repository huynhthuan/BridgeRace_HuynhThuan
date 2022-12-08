using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameState : IStateGame
{
    public void OnEnter(GameManager gameManger) { }

    public void OnExecute(GameManager gameManger) {
        gameManger.enableJoystick = true;
        gameManger.isPlayGame = true;
    }

    public void OnExit(GameManager gameManger) { }
}
