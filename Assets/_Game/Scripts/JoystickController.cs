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
    private RaycastHit groundHit;

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

        if (OnGround())
        {
            rb.velocity = direction * speed * Time.deltaTime;
        }



        if (OnSlope())
        {
            Debug.Log("On slope");
            transform.position = new Vector3(transform.position.x, slopeHit.point.y, transform.position.z);
        }
    }


    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, Mathf.Infinity))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle > 0;
        }

        return false;
    }

    public bool OnGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out groundHit, Mathf.Infinity))
        {
            Debug.Log("Hit " + groundHit.point);
            Debug.DrawRay(
               transform.position,
               transform.TransformDirection(Vector3.down) * groundHit.distance,
               Color.yellow
           );

            return Vector3.Distance(transform.position, groundHit.point) <= 1f;

        }
        return false;
    }

    public void FixedUpdate()
    {


    }
}
