using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class BrickHolder : Singleton<BrickHolder>
{
    [SerializeField]
    private GameObject brickHeldPrefab;

    public Stack<GameObject> stackBrickIsHeld = new Stack<GameObject>();

    public int brickAmount => stackBrickIsHeld.Count;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        // Reset brick held
        RemoveAllBrick();
    }

    public void SuckBrick(Vector3 brickPosition) { }

    public void AddBrick()
    {
        GameObject brickGameobject = brickHeldPrefab.gameObject;
        GameObject brickHeld = Instantiate(brickGameobject, transform, false);
        Brick brickHeldComp = brickHeld.GetComponent<Brick>();
        brickHeldComp.OnInit(GameManager.Instance.playerColorTarget, Vector3.zero);
        stackBrickIsHeld.Push(brickHeld);
        brickHeld.transform.localPosition = BrickNumberToPosition(brickAmount);
    }

    public void RemoveBrick()
    {
        if (brickAmount == 0)
        {
            return;
        }
        Destroy(stackBrickIsHeld.Pop());
    }

    public void RemoveAllBrick()
    {
        stackBrickIsHeld.Clear();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public Vector3 BrickNumberToPosition(int rowNumber)
    {
        return Vector3.up * ((rowNumber * 0.1f) - 0.1f);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(BrickHolder))]
public class BrickHolderButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Add 1 brick is held"))
        {
            ((BrickHolder)target).AddBrick();
        }

        if (GUILayout.Button("Remove 1 brick is held"))
        {
            ((BrickHolder)target).RemoveBrick();
        }
    }
}
#endif
