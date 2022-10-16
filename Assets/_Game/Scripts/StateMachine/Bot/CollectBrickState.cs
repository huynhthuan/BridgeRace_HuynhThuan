using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrickState : IStateBot
{
    void IStateBot.OnEnter(Bot bot) { }

    void IStateBot.OnExecute(Bot bot)
    {
        Vector3 dirToTarget = bot.GetDirToBrickCollect();
        bot.joystickController.Move(dirToTarget);
        if (Vector3.Distance(bot.transform.position, bot.brickTartget.position) <= 0.01f)
        {
            bot.ChangeState(new BotIdleState());
        }
    }

    void IStateBot.OnExit(Bot bot) { }
}
