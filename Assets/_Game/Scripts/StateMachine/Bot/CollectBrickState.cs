using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrickState : IStateBot
{
    private Vector3 dirToTarget;

    public void OnEnter(BotAI bot)
    {
        bot.limitBrickHolder = Random.Range(1, bot.player.amountBrickdivided);
    }

    public void OnExecute(BotAI bot)
    {
        bot.ScanAllBrick();
        dirToTarget = bot.GetDirToBrickCollect();
        bot.player.Move(dirToTarget);
        if (bot.player.brickHolder.brickAmount == bot.limitBrickHolder)
        {
            bot.ChangeState(new MoveToBridgeState());
        }
    }

    public void OnExit(BotAI bot) { }
}
