using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStage : MonoBehaviour
{
    public Stage stage;

    public void OnTriggerEnter(Collider other)
    {
        Character player = other.GetComponent<Character>();

        if (player == null)
        {
            return;
        }

        if (stage.playerInStage.Contains(player))
        {
            return;
        }

        Debug.Log("Init stage " + stage.stageLevel);
        player.brickHolder.RemoveAllBrick();
        player.currentStage = stage;
        stage.EnableBrickColor(player.colorTarget);
        stage.playerInStage.Add(player);
    }
}
