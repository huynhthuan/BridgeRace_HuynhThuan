using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private FixedJoystick fixedJoystick;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void FixedUpdate()
    {
        Vector3 direction =
            Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        Debug.Log("Dirrection " + direction);
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
