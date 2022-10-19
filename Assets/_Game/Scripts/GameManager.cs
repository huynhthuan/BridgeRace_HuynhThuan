using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private int botNumber;

    [SerializeField]
    private GameObject botPrefab;

    [SerializeField]
    public Material[] listColor;

    [SerializeField]
    public Player player;

    [SerializeField]
    public BrickColor playerColorTarget = BrickColor.COLOR1;

    [SerializeField]
    public List<Player> playersInGame;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Transform map;

    public bool enableJoystick = true;

    private LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    void OnInit()
    {
        levelController = map.GetComponentInChildren<LevelController>();

        enableJoystick = true;
        player.OnInit(playerColorTarget);
        playersInGame.Add(player);

        levelController.OnInit();

        Debug.Log("player.currentStageLevel " + player.currentStageLevel);
        GetStageByLevel(1)
            .GetComponent<StageManager>()
            .AddColorStage(playerColorTarget, player.currentStageLevel);

        // InitBot();
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
                player.transform.position.x + (botIndex % 2 == 0 ? 2f : -2f),
                Random.Range(2, 4),
                player.transform.position.z
            ),
            Quaternion.identity
        );
        Player botPlayerComp = botObject.GetComponent<Player>();
        botPlayerComp.OnInit((BrickColor)botIndex);
        playersInGame.Add(botPlayerComp);
        levelController.listStage[0]
            .GetComponent<StageManager>()
            .AddColorStage((BrickColor)botIndex, botPlayerComp.currentStageLevel);
    }

    public void InitBot()
    {
        for (int i = 0; i < botNumber; i++)
        {
            SpawnBot(i + 2);
        }
    }

    public void SwitchCameraToFinishStage()
    {
        // mainCamera.transform.position =
    }

    public GameObject GetStageByLevel(int levelStage)
    {
        return levelController.listStage[levelStage - 1].gameObject;
    }
}
