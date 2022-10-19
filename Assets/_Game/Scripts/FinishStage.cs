using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStage : MonoBehaviour
{
    [SerializeField]
    private Transform[] rankPoints;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnFinishLevel();
        }
    }

    private void OnFinishLevel()
    {
        GameManager.Instance.enableJoystick = false;

        List<Player> playersInGame = GameManager.Instance.playersInGame;
        playersInGame.Sort(
            (Player a, Player b) => a.currentStageLevel.CompareTo(b.currentStageLevel)
        );

        for (int i = 0; i < rankPoints.Length; i++)
        {
            playersInGame[i].transform.position = rankPoints[i].position;
        }

        GameManager.Instance.SwitchCameraToFinishStage();
    }
}
