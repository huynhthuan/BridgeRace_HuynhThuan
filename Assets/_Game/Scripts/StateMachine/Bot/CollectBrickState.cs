using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrickState : IStateBot
{
    private Vector3 dirToTarget;

    public void OnEnter(Bot bot) { }

    public void OnExecute(Bot bot)
    {
        bot.ScanAllBrick();
        dirToTarget = bot.GetDirToBrickCollect();
        // Debug.Log("dirToTarget " + dirToTarget);
        bot.Move(dirToTarget);
        // bot.ChangeState(new MoveToBridgeState());
    }

    public void OnExit(Bot bot) { }
}
