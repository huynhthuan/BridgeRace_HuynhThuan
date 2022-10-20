using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public Player player;

    [SerializeField]
    public BrickColor playerColorTarget = BrickColor.COLOR1;

    [SerializeField]
    private int botNumber;

    [SerializeField]
    private GameObject botPrefab;

    [SerializeField]
    public List<Player> playersInGame;

    [SerializeField]
    public Material[] listColor;

    [SerializeField]
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    void OnInit()
    {
        InitPlayer();
        InitBot();

        LevelManager.Instance.OnInit();
    }

    public void InitPlayer()
    {
        player.OnInit(playerColorTarget);
    }

    public void InitBot()
    {
        for (int i = 0; i < botNumber; i++)
        {
            SpawnBot(i + 2);
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
                player.transform.position.x + (botIndex % 2 == 0 ? 2f : -2f),
                Random.Range(2, 4),
                player.transform.position.z
            ),
            Quaternion.identity
        );
        Bot botPlayerComp = botObject.GetComponent<Bot>();
        botPlayerComp.OnInit((BrickColor)botIndex);
    }

    public void SwitchCameraToFinishStage()
    {
        // mainCamera.transform.position =
    }
}
