using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Bot : Character
{
    private IStateBot currentState;
    private Dictionary<int, float> dictionaryBrick = new Dictionary<int, float> { };
    private Transform brickTartget;
    public int limitBrickHolder = 1;
    public NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ChangeState(new BotIdleState());
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void ChangeState(IStateBot newState)
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

    public void ClearDictionaryBrick()
    {
        dictionaryBrick.Clear();
    }

    public void ScanAllBrick()
    {
        ClearDictionaryBrick();

        Transform brickPlan = currentStage.planBrick;

        for (int index = 0; index < brickPlan.childCount; index++)
        {
            Brick brickComp = brickPlan.GetChild(index).GetComponent<Brick>();

            if (brickComp.color == colorTarget && brickComp.gameObject.activeSelf)
            {
                dictionaryBrick.Add(
                    index,
                    Vector3.Distance(transform.position, brickComp.transform.position)
                );
            }
        }
    }

    public Vector3 GetDirToBrickCollect()
    {
        if (dictionaryBrick.Count == 0)
        {
            return Vector3.zero;
        }

        int indexBrickNearest = dictionaryBrick.Aggregate((x, y) => x.Value <= y.Value ? x : y).Key;

        Transform nearestBrick = currentStage.planBrick.transform.GetChild(indexBrickNearest);

        brickTartget = nearestBrick;

        nearestBrick
            .GetComponent<Brick>()
            .targetSelect.gameObject.GetComponent<TargetSelect>()
            .ActiveSelect();

        return brickTartget.position;
    }
}
