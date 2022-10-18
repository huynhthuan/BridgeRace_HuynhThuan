using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotIdleState : IStateBot
{
    float randomTime;
    float timer;

    public void OnEnter(BotAI bot)
    {
        timer = 0;
        randomTime = Random.Range(2f, 4f);
        bot.limitBrickHolder = Random.Range(1, GameManager.Instance.CountPlayer());
    }

    public void OnExecute(BotAI bot)
    {
        bot.player.rb.velocity = Vector3.zero;

        timer += Time.deltaTime;

        if (timer > randomTime)
        {
            bot.ChangeState(new CollectBrickState());
        }
    }

    public void OnExit(BotAI bot) { }
}
