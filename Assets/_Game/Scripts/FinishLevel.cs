using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinishLevel : MonoBehaviour
{
    private FinishStage finishStage;

    // Start is called before the first frame update
    void Start()
    {
        finishStage = GetComponentInParent<FinishStage>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.ChangeState(new FinishGameState());

            LevelManager.Instance.player.rb.velocity = Vector3.zero;

            List<Character> playersInGame = GameManager.Instance.playersInGame;

            playersInGame.Sort(
                (Character a, Character b) =>
                    a.currentStage.stageLevel.CompareTo(b.currentStage.stageLevel)
            );

            for (int i = 0; i < finishStage.planRankPoints.Length; i++)
            {
                if (playersInGame.Count < i + 1)
                {
                    break;
                }

                if (playersInGame[i].GetComponent<Bot>() != null)
                {
                    NavMeshAgent botAgent = playersInGame[i].GetComponent<NavMeshAgent>();
                    botAgent.enabled = false;
                    playersInGame[i].GetComponent<CapsuleCollider>().isTrigger = false;
                }

                playersInGame[i].rb.velocity = Vector3.zero;
                playersInGame[i].rb.rotation = Quaternion.identity;
                playersInGame[i].rb.rotation = Quaternion.Euler(0f, 180f, 0);
                playersInGame[i].brickHolder.RemoveAllBrick();
                playersInGame[i].transform.position = finishStage.planRankPoints[i].position;
                playersInGame[i].ChangeAnim("Victory");
            }

            LevelManager.Instance.SwitchCameraFinishStage();
        }
    }
}
