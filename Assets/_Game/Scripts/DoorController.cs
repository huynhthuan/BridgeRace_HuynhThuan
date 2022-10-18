using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private Transform door1;

    [SerializeField]
    private Transform door2;

    private StageManager stageManager;

    // Start is called before the first frame update
    void Start()
    {
        stageManager = GetComponentInParent<StageManager>();
    }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        Player playerComp = other.gameObject.GetComponent<Player>();

        if (playerComp && !stageManager.playersInStage.Contains(playerComp))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        door1.position = Vector3.MoveTowards(
            door1.position,
            new Vector3(1.5f, door1.position.y, door1.position.z),
            0.1f
        );

        door2.position = Vector3.MoveTowards(
            door2.position,
            new Vector3(-1.5f, door2.position.y, door2.position.z),
            0.1f
        );
    }

    public void CloseDoor()
    {
        door1.position = Vector3.MoveTowards(
            door1.position,
            new Vector3(1.66f, door1.position.y, door1.position.z),
            0.1f
        );

        door2.position = Vector3.MoveTowards(
            door2.position,
            new Vector3(-1.66f, door2.position.y, door2.position.z),
            0.1f
        );
    }
}
