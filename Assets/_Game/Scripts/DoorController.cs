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

    internal Stage stage;
    private bool isOpenDoors = false;
    private int playerAmount;

    // Start is called before the first frame update
    void Start()
    {
        stage = GetComponentInParent<Stage>();
        playerAmount = GameManager.Instance.CountPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("other.tag " + other.tag);
            Character characterComp = other.GetComponent<Character>();

            if (characterComp && characterComp.currentStage.stageLevel != stage.stageLevel)
            {
                OpenDoor();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit door " + other.tag);
        if (other.tag == "Player")
        {
            StartCoroutine(CloseDoorCoroutine());
        }
    }

    IEnumerator CloseDoorCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

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
            0.1f
        );

        door2.localPosition = Vector3.MoveTowards(
            door2.localPosition,
            new Vector3(isOpenDoors ? 4.5f : 1.5f, door2.localPosition.y, door2.localPosition.z),
            0.1f
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
