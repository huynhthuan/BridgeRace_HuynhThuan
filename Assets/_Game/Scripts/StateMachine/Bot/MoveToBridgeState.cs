using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBridgeState : IStateBot
{
    public void OnEnter(BotAI bot) { }

    public void OnExecute(BotAI bot)
    {
        if (!bot.player.isCanMove)
        {
            bot.ChangeState(new CollectBrickState());
        }

        bot.GotoNextStage();
    }

    public void OnExit(BotAI bot) { }
}
