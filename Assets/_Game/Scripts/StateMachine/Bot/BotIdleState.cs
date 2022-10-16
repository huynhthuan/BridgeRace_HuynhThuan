using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotIdleState : IStateBot
{
    void IStateBot.OnEnter(Bot bot)
    {
        bot.limitBrickHolder = Random.Range(1, GameManager.Instance.CountPlayer());
        bot.rb.velocity = Vector3.zero;
    }

    void IStateBot.OnExecute(Bot bot)
    {
        bot.ScanAllBrick();
        bot.ChangeState(new CollectBrickState());
    }

    void IStateBot.OnExit(Bot bot) { }
}
