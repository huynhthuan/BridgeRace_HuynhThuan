using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] listBrickPosition;

    [SerializeField]
    private GameObject brickPrefab;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        GenerateBrickPlan();
    }

    public void GenerateBrickPlan()
    {
        if (listBrickPosition.Length == 0)
        {
            return;
        }
        foreach (Transform brickPos in listBrickPosition)
        {
            GameObject brickObject = Instantiate(brickPrefab, Vector3.zero, Quaternion.identity);
            brickObject.SetActive(true);
            brickObject.transform.SetParent(transform);
            brickObject.GetComponent<Brick>().OnInit(BRICK_COLOR.BLUE, brickPos.position);
        }
    }

    // Update is called once per frame
    void Update() { }
}
