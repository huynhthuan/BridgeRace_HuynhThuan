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
    public BrickColor playerColorTarget = BrickColor.COLOR1;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    void OnInit()
    {
        for (int i = 0; i < botNumber; i++)
        {
            SpawnBot();
        }
    }

    public int CountPlayer()
    {
        return botNumber + 1;
    }

    public void SpawnBot()
    {
        GameObject botObject = Instantiate(
            botPrefab,
            new Vector3(Random.Range(-5, 5), Random.Range(2, 4), 0),
            Quaternion.identity
        );
    }
}
