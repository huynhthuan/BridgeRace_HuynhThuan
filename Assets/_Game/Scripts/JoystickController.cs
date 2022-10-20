using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private DynamicJoystick dynamicJoystick;

    private Player playerController;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.Instance.enableJoystick)
        {
            return;
        }

        Vector3 direction =
            Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        playerController.Move(direction);
    }
}
