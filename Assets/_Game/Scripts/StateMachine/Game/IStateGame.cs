using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateGame
{
    // Enter state
    void OnEnter(GameManager gameManger);

    // Stay state
    void OnExecute(GameManager gameManger);

    // Exit state
    void OnExit(GameManager gameManger);
}
