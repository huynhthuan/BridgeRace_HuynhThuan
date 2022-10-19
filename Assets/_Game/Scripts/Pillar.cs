using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private StageManager stageManager;
    // Start is called before the first frame update
    void Start() {
        stageManager = GetComponentInParent<StageManager>();
    }

    // Update is called once per frame
    void Update() { }


}
