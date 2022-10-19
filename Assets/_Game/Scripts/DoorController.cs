using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private Transform door1;

    [SerializeField]
    private Transform door2;

    internal StageManager stageManager;
    private bool isOpenDoors = false;
    private int playerAmount;

    // Start is called before the first frame update
    void Start()
    {
        stageManager = GetComponentInParent<StageManager>();
        playerAmount = GameManager.Instance.CountPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other.tag " + other.tag);
        Player playerComp = other.gameObject.GetComponent<Player>();

        if (playerComp)
        {
            if (
                !stageManager.colorInStage.Contains(playerComp.brickColorTarget)
                && !(playerComp.velocityAdjust.y < 0)
            )
            {
                OpenDoor();

                playerComp.currentStageLevel++;

                GameObject currentStage = GameManager.Instance.GetStageByLevel(
                    playerComp.currentStageLevel
                );
                StageManager currentStageComp = currentStage.GetComponent<StageManager>();

                playerComp.amountBrickdivided = currentStageComp.brickAmount / playerAmount;

                stageManager.AddColorStage(
                    playerComp.brickColorTarget,
                    playerComp.currentStageLevel
                );
            }
            else if (!(playerComp.velocityAdjust.y < 0))
            {
                OpenDoor();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit door " + other.tag);
        CloseDoor();
    }

    public void OpenDoor()
    {
        isOpenDoors = true;
    }

    public void CloseDoor()
    {
        isOpenDoors = false;
    }

    private void Update()
    {
        door1.localPosition = Vector3.MoveTowards(
            door1.localPosition,
            new Vector3(isOpenDoors ? -4.5f : -1.5f, door1.localPosition.y, door1.localPosition.z),
            0.05f
        );

        door2.localPosition = Vector3.MoveTowards(
            door2.localPosition,
            new Vector3(isOpenDoors ? 4.5f : 1.5f, door2.localPosition.y, door2.localPosition.z),
            0.05f
        );
    }
}

// #if UNITY_EDITOR
[CustomEditor(typeof(DoorController))]
public class DoorsButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Open door"))
        {
            ((DoorController)target).OpenDoor();
        }

        if (GUILayout.Button("Close door"))
        {
            ((DoorController)target).CloseDoor();
        }
    }
}
// #endif
