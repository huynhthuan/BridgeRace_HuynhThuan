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
    public BRICK_COLOR playerColorTarget = BRICK_COLOR.COLOR1;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    void OnInit() { }

    // Update is called once per frame
    void Update()
    {
        // joystick.AxisOptions;
    }

    public int CountPlayer()
    {
        return botNumber + 1;
    }
}
