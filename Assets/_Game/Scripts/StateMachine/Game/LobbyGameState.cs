using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyGameState : IStateGame
{
    public void OnEnter(GameManager gameManger)
    {
        UIManager.Instance.OpenUI<Lobby>();
        GameManager.Instance.OnInit();
    }

    public void OnExecute(GameManager gameManger)
    {
        GameManager.Instance.enableJoystick = false;
    }

    public void OnExit(GameManager gameManger) { }
}
