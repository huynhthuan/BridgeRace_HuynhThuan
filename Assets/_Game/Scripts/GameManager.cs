using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public Player player;

    [SerializeField]
    public List<Character> playersInGame;

    [SerializeField]
    public Material[] listColor;

    public bool enableJoystick = true;
    public bool isPlayGame = false;
    private IStateGame currentState;

    protected void Awake()
    {
        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        int maxScreenHeight = 1280;
        float ratio =
            (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(
                Mathf.RoundToInt(ratio * (float)maxScreenHeight),
                maxScreenHeight,
                true
            );
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new LobbyGameState());
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void OnInit()
    {

        LevelManager.Instance.OnInit();
    }

    public void ChangeState(IStateGame newState)
    {
        // Check has current state
        if (currentState != null)
        {
            // Exit current state
            currentState.OnExit(this);
        }

        // Set new state
        currentState = newState;

        // Check set new state success
        if (currentState != null)
        {
            // Enter new state
            currentState.OnEnter(this);
        }
    }
}
