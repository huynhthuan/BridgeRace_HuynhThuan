using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private FinishStage finishStage;

    // Start is called before the first frame update
    void Start()
    {
        finishStage = GetComponentInParent<FinishStage>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelManager.Instance.OnFinishLevel();
        }
    }


}
