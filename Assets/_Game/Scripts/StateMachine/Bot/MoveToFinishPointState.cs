using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToFinishPointState : IStateBot
{
    public void OnEnter(Bot bot) { }

    public void OnExecute(Bot bot)
    {
        if (bot.brickHolder.brickAmount == 0)
        {
            bot.ChangeState(new CollectBrickState());
        }

        if (bot.navMeshAgent.enabled)
        {
            bot.navMeshAgent.destination = LevelManager.Instance.finishLevelPoint.position;
        }
    }

    public void OnExit(Bot bot) { }
}
