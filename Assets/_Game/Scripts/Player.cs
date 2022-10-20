using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Vector3 velocityAdjust;

    // Start is called before the first frame update
    void Start() { }

    public bool IsGrounded()
    {
        float distance = colliderPlayer.bounds.extents.y + 0.1f;
        Vector3 centerPoint = colliderPlayer.bounds.center;

        Debug.DrawRay(centerPoint, Vector3.down * distance, Color.red);

        if (Physics.Raycast(centerPoint, Vector3.down, out groundHit, distance, layerMask))
        {
            string tagCollider = groundHit.collider.tag;
            if (
                tagCollider == "Ground"
                || tagCollider == "Brick"
                || tagCollider == "Brigde"
                || tagCollider == "New stage"
            )
            {
                return true;
            }
        }

        return false;
    }

    public bool IsOnBrigde()
    {
        float distance = colliderPlayer.bounds.extents.y + 0.1f;
        Vector3 centerPoint = colliderPlayer.bounds.center;

        Debug.DrawRay(centerPoint, Vector3.down * distance, Color.yellow);

        if (Physics.Raycast(centerPoint, Vector3.down, out groundHit, distance, layerMask))
        {
            string tagCollider = groundHit.collider.tag;
            return tagCollider == "Brigde";
        }

        return false;
    }

    public void Move(Vector3 direction)
    {
        if (Vector3.Distance(direction, Vector3.zero) > 0.01f)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            rb.transform.rotation = rotation;
        }

        if (!isCanMove)
        {
            rb.velocity = Vector3.zero;

            return;
        }

        if (IsGrounded() && isCanMove)
        {
            velocityAdjust = AdjustVelocityToSlope(direction * speed * Time.fixedDeltaTime);
            rb.velocity = velocityAdjust;
        }
    }

    public Vector3 AdjustVelocityToSlope(Vector3 velocity)
    {
        Quaternion slopRotation = Quaternion.FromToRotation(Vector3.up, groundHit.normal);

        Vector3 adjustVelocity = slopRotation * velocity;
        if (adjustVelocity.y < 0)
        {
            return adjustVelocity;
        }
        return velocity;
    }
}
