using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private int botNumber;

    [SerializeField]
    public Material[] listColor;

    [SerializeField]
    public BrickColor playerColorTarget = BrickColor.COLOR1;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    void OnInit() { }

    public int CountPlayer()
    {
        return botNumber + 1;
    }
}
