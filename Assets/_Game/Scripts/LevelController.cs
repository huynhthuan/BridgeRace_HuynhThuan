using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    [SerializeField]
    public GameObject brickPrefab;

    [SerializeField]
    public Transform planBrick;

    [SerializeField]
    public Transform[] listStage;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnInit()
    {
        foreach (Transform stage in listStage)
        {
            stage.GetComponent<StageManager>().OnInit();
        }
    }

    public Transform GetBrickObjectByIndex(int index)
    {
        return planBrick.GetChild(index);
    }
}
