using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Text score;

    public void BackLobbyButton()
    {
        GameManager.Instance.ChangeState(new LobbyGameState());
        UIManager.Instance.OpenUI<Lobby>();
        Close();
    }
}
