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

    [SerializeField]
    private float rotationSpeed;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction =
            Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;

        if (Player.Instance.onGround)
        {
            rb.velocity = direction * speed * Time.deltaTime;
        }

        if (Vector3.Distance(direction, Vector3.zero) > 0.01f)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            rb.transform.rotation = rotation;
        }

        if (Player.Instance.onSlope)
        {
            rb.useGravity = false;
            float yPos = Player.Instance.slopeHit.point.y + 1f;
            // Debug.Log("V3 " + new Vector3(transform.position.x, yPos, transform.position.z));
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
        else
        {
            rb.useGravity = true;
        }
    }
}
