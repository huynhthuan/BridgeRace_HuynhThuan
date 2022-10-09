using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private DynamicJoystick dynamicJoystick;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction =
            Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        // Debug.Log("Dirrection " + direction);

        rb.velocity = direction * speed * Time.deltaTime;
    }

    public void FixedUpdate()
    {
        // Vector3 direction =
        //     Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        // // Debug.Log("Dirrection " + direction);

        // rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
