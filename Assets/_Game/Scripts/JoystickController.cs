using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private DynamicJoystick dynamicJoystick;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction =
            Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;

        Move(direction);
    }

    public void Move(Vector3 direction)
    {
        if (Player.Instance.IsGrounded())
        {
            Vector3 velocityAdjust = AdjustVelocityToSlope(
                direction * Player.Instance.speed * Time.deltaTime
            );

            Collider collider = CollisionSensor.Instance.GetCurrentCollider();

            if (
                BrickHolder.Instance.brickAmount == 0
                && Player.Instance.IsOnBrigde()
                && !(velocityAdjust.y < 0)
                && collider.tag == "Brigde Brick"
                && collider.gameObject.GetComponent<BrickBrigde>().currentColor == BrickColor.COLOR0
            )
            {
                Player.Instance.rb.velocity = Vector3.zero;
                return;
            }

            Player.Instance.rb.velocity = velocityAdjust;
        }

        if (Vector3.Distance(direction, Vector3.zero) > 0.01f)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            Player.Instance.rb.transform.rotation = rotation;
        }
    }

    public Vector3 AdjustVelocityToSlope(Vector3 velocity)
    {
        Quaternion slopRotation = Quaternion.FromToRotation(
            Vector3.up,
            Player.Instance.groundHit.normal
        );

        Vector3 adjustVelocity = slopRotation * velocity;
        if (adjustVelocity.y < 0)
        {
            return adjustVelocity;
        }
        return velocity;
    }
}
