using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotIdleState : IStateBot
{
    float randomTime;
    float timer;

    public void OnEnter(Bot bot) { }

    public void OnExecute(Bot bot)
    {
        bot.rb.velocity = Vector3.zero;

        if (GameManager.Instance.isPlayGame)
        {
            bot.ChangeState(new CollectBrickState());
        }
    }

    public void OnExit(Bot bot) { }
}
