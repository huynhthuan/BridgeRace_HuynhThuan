using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MainMenu : UICanvas
{
    public void PlayButton()
    {
        UIManager.Instance.OpenUI<GamePlay>();
        Close();
    }
}
