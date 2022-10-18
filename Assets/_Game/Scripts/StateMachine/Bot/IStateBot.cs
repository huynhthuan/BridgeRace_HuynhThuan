using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateBot
{
    // Enter state
    void OnEnter(BotAI bot);

    // Stay state
    void OnExecute(BotAI bot);

    // Exit state
    void OnExit(BotAI bot);
}
