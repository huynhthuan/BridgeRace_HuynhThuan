using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
    public void WinButton()
    {
        UIManager.Instance.OpenUI<Win>().score.text = Random.Range(10, 99).ToString();
        Close();
    }

    public void LoseButton()
    {
        UIManager.Instance.OpenUI<Lose>().score.text = Random.Range(10, 50).ToString();
        Close();
    }

    public void SettingButton()
    {
        UIManager.Instance.OpenUI<Setting>();
        Close();
    }
}
