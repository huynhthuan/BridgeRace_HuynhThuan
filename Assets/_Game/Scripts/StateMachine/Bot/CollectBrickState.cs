using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrickState : IStateBot
{
    private Vector3 dirToTarget;

    public void OnEnter(BotAI bot) { }

    public void OnExecute(BotAI bot)
    {
        bot.ScanAllBrick();
        dirToTarget = bot.GetDirToBrickCollect();
        // Debug.Log("dirToTarget " + dirToTarget);
        bot.player.Move(dirToTarget);
        // bot.ChangeState(new MoveToBridgeState());
    }

    public void OnExit(BotAI bot) { }
}
