using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = GameManager.Instance.listColor[
            (int)GetComponentInParent<Brick>().color
        ];
        DeActiveSelect();
    }

    public void ActiveSelect()
    {
        gameObject.SetActive(true);
    }

    public void DeActiveSelect()
    {
        gameObject.SetActive(false);
    }
}
