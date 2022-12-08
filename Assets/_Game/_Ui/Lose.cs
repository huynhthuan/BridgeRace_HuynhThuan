using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : UICanvas
{
    public Text score;

    public void ReplayButton()
    {
        Close();
        SceneManager.LoadScene("MainScene");
    }
}
