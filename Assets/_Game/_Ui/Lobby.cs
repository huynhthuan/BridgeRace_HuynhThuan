using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : UICanvas
{
    public void ReadyButton()
    {
        UIManager.Instance.OpenUI<MainMenu>();
        Close();
    }
}
