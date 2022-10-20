using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStage : MonoBehaviour
{
    public Stage stage;

    public void OnTriggerEnter(Collider other)
    {
        Character player = other.GetComponent<Character>();

        if (player != null)
        {
            player.currentStage = stage;
            stage.EnableBrickColor(player.colorTarget);
        }
    }
}
