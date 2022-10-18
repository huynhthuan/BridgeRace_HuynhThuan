using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    public BrickColor brickColorTarget;

    [SerializeField]
    public BrickHolder brickHolder;

    [SerializeField]
    public Collider colliderPlayer;

    [SerializeField]
    public CollisionSensor collisionSensor;

    [SerializeField]
    public Rigidbody rb;

    [SerializeField]
    public float speed;

    public RaycastHit groundHit;

    public LayerMask layerMask;

    public int currentStageLevel = 0;

    public bool isCanMove = true;

    // Start is called before the first frame update
    void Start() { }

    public void OnInit(BrickColor color)
    {
        SetColorTarget(color);
        brickHolder.OnInit(color);
        collisionSensor.OnInit(brickHolder, color);
    }

    public void SetPositionPlayer(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private void Update() { }

    public bool IsGrounded()
    {
        float distance = colliderPlayer.bounds.extents.y + 0.1f;
        Vector3 centerPoint = colliderPlayer.bounds.center;

        Debug.DrawRay(centerPoint, Vector3.down * distance, Color.yellow);

        if (Physics.Raycast(centerPoint, Vector3.down, out groundHit, distance, layerMask))
        {
            string tagCollider = groundHit.collider.tag;
            if (tagCollider == "Ground" || tagCollider == "Brick" || tagCollider == "Brigde")
            {
                return true;
            }
        }

        return false;
    }

    public bool IsOnBrigde()
    {
        Debug.Log("brickHolder.brickAmount" + (brickHolder.brickAmount == 0));

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
        if (IsGrounded() && isCanMove)
        {
            Vector3 velocityAdjust = AdjustVelocityToSlope(direction * speed * Time.deltaTime);

            rb.velocity = velocityAdjust;
        }

        if (!isCanMove)
        {
            rb.velocity = Vector3.zero;
        }

        if (Vector3.Distance(direction, Vector3.zero) > 0.01f)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            rb.transform.rotation = rotation;
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

    public void SetColorTarget(BrickColor color)
    {
        brickColorTarget = color;
    }
}
