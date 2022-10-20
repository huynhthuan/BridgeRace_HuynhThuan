using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    public GameObject brickPrefab;

    [SerializeField]
    public Stage[] listStage;

    [SerializeField]
    public Transform finishLevelPoint;

    [SerializeField]
    public Vector3 cameraEndPoint;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnInit()
    {
        foreach (Stage stage in listStage)
        {
            stage.OnInit();
        }
    }
}
