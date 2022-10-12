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
    private RaycastHit slopeHit;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction =
            Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;

        rb.useGravity = !OnSlope();

        if (Vector3.Distance(direction, Vector3.zero) > 0.01f)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            rb.transform.rotation = rotation;
        }

        if (OnSlope())
        {
            rb.velocity = GetSlopeMoveDirection() * speed * 20f;

            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        rb.velocity = direction * speed * Time.deltaTime;

        Debug.DrawRay(
            transform.position,
            transform.TransformDirection(Vector3.down) * Mathf.Infinity,
            Color.yellow
        );
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, Mathf.Infinity))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < 40f && angle != 0;
        }

        return false;
    }

    public void FixedUpdate() { }
}
