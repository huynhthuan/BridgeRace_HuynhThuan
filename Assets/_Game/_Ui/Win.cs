using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : UICanvas
{
    public Text score;

    public void BackLobbyButton()
    {
        Close();
        SceneManager.LoadScene("MainScene");
    }
}
