using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private FixedJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    void OnInit() {

    }

    // Update is called once per frame
    void Update()
    {
        // joystick.AxisOptions;
    }
}
