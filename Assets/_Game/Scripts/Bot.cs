using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bot : Character
{
    private IStateBot currentState;

    private Dictionary<int, float> dictionaryBrick = new Dictionary<int, float> { };

    public Transform brickTartget;

    public int limitBrickHolder;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new BotIdleState());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null && IsGrounded())
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

    public void ScanAllBrick()
    {
        ClearDictionaryBrick();

        Transform brickPlan = StageManager.Instance.planBrick;

        for (int index = 0; index < brickPlan.childCount; index++)
        {
            Brick brickComp = brickPlan.GetChild(index).GetComponent<Brick>();

            if (brickComp.color == brickColorTarget && brickComp.gameObject.activeSelf)
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

        Transform nearestBrick = StageManager.Instance.planBrick.transform.GetChild(
            indexBrickNearest
        );

        brickTartget = nearestBrick;

        nearestBrick
            .GetComponent<Brick>()
            .targetSelect.gameObject.GetComponent<TargetSelect>()
            .ActiveSelect();

        return (
            new Vector3(nearestBrick.position.x, transform.position.y, nearestBrick.position.z)
            - transform.position
        ).normalized;
    }

    public void ClearDictionaryBrick()
    {
        dictionaryBrick.Clear();
    }
}
