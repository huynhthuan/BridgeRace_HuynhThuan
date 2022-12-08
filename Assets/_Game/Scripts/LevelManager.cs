using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    public GameObject brickPrefab;

    [SerializeField]
    public Stage[] listStage;

    [SerializeField]
    public Transform startPoint;

    [SerializeField]
    public Transform finishLevelPoint;

    [SerializeField]
    public BrickColor playerColorTarget = BrickColor.COLOR1;

    [SerializeField]
    private int botNumber;

    [SerializeField]
    private GameObject botPrefab;

    [SerializeField]
    public Camera mainCamera;

    [SerializeField]
    public Camera cameraFinish;

    public Player player;

    private Transform startPointTransform;
    private List<Bot> botIngame = new List<Bot>();

    [SerializeField]
    private FinishStage finishStage;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnInit()
    {
        player = GameManager.Instance.player;
        startPointTransform = startPoint.GetComponent<Transform>();
        InitPlayer();

        if (botIngame.Count > 0)
        {
            for (int i = 0; i < botIngame.Count; i++)
            {
                Destroy(botIngame[i].gameObject);
            }
        }

        InitBot();

        SwitchMainCamera();

        foreach (Stage stage in listStage)
        {
            stage.OnInit();
        }
    }

    public void InitPlayer()
    {
        player.OnInit(playerColorTarget);
        player.SetPositionPlayer(startPointTransform.position);
    }

    public void InitBot()
    {
        for (int i = 0; i < botNumber; i++)
        {
            SpawnBot(i + 1);
        }
    }

    public int CountPlayer()
    {
        return botNumber + 1;
    }

    public void SpawnBot(int botIndex)
    {
        GameObject botObject = Instantiate(
            botPrefab,
            new Vector3(
                startPointTransform.position.x
                    + (botIndex % 2 == 0 ? 4f * (botIndex - 1) : -4f * botIndex),
                startPointTransform.position.y,
                startPointTransform.position.z
            ),
            Quaternion.identity
        );
        Bot botPlayerComp = botObject.GetComponent<Bot>();
        botIngame.Add(botPlayerComp);
        botPlayerComp.OnInit((BrickColor)botIndex + 1);
    }

    public void SwitchCameraFinishStage()
    {
        mainCamera.enabled = false;
        cameraFinish.enabled = true;
    }

    public void SwitchMainCamera()
    {
        mainCamera.enabled = true;
        cameraFinish.enabled = false;
    }

    public void OnFinishLevel()
    {
        GameManager.Instance.ChangeState(new FinishGameState());

        LevelManager.Instance.player.rb.velocity = Vector3.zero;

        List<Character> playersInGame = GameManager.Instance.playersInGame;

        playersInGame.Sort(
            (Character a, Character b) =>
                a.currentStage.stageLevel.CompareTo(b.currentStage.stageLevel)
        );

        if (playersInGame[playersInGame.Count - 1] is Player)
        {
            UIManager.Instance.OpenUI<Win>();
        }
        else
        {
            UIManager.Instance.OpenUI<Lose>();
        }

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
