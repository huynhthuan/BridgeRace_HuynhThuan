using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BRICK_COLOR brickColorTarget;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit() { }

    // Update is called once per frame
    void Update() { }

    public void SetPositionPlayer(Vector3 newPosition)
    {
        transform.position = newPosition;
    }




}
