using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrickState : IStateBot
{
    private Vector3 dirToTarget;

    public void OnEnter(Bot bot)
    {
        bot.ChangeAnim("Run");
        bot.limitBrickHolder = Random.Range(1, bot.currentStage.brickPerPlayer);
        Debug.Log("bot.amountBrickdivided  " + bot.amountBrickdivided);
        Debug.Log("bot.limitBrickHolder  " + bot.limitBrickHolder);
    }

    public void OnExecute(Bot bot)
    {
        if (bot.brickHolder.brickAmount == bot.limitBrickHolder)
        {
            bot.ChangeState(new MoveToFinishPointState());
        }

        bot.ScanAllBrick();
        Vector3 bricKPostTarget = bot.GetDirToBrickCollect();
        if (bot.navMeshAgent.enabled)
        {
            bot.navMeshAgent.destination = bricKPostTarget;
        }
    }

    public void OnExit(Bot bot) { }
}
