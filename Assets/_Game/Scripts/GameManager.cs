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

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    void OnInit()
    {
        player.OnInit(playerColorTarget);
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
    }

    public void InitBot()
    {
        for (int i = 0; i < botNumber; i++)
        {
            SpawnBot(i + 2);
        }
    }
}
