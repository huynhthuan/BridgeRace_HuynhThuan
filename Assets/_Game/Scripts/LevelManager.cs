using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnInit()
    {
        player = GameManager.Instance.player;
        startPointTransform = startPoint.GetComponent<Transform>();
        InitPlayer();
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
}
