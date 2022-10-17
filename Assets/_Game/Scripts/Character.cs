using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    public BrickColor brickColorTarget;

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

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit() { }

    public void SetPositionPlayer(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private void Update()
    {
        Debug.Log(gameObject.name + " IsGrounded() " + IsGrounded());
    }

    public bool IsGrounded()
    {
        float distance = colliderPlayer.bounds.extents.y + 0.1f;
        Vector3 centerPoint = colliderPlayer.bounds.center;

        Debug.DrawRay(centerPoint, Vector3.down * distance, Color.yellow);

        if (Physics.Raycast(centerPoint, Vector3.down, out groundHit, distance, layerMask))
        {
            string tagCollider = groundHit.collider.tag;
            return tagCollider == "Ground" || tagCollider == "Brick" || tagCollider == "Brigde";
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
        if (IsGrounded())
        {
            Vector3 velocityAdjust = AdjustVelocityToSlope(direction * speed * Time.deltaTime);

            Collider collider = CollisionSensor.Instance.GetCurrentCollider();

            if (
                BrickHolder.Instance.brickAmount == 0
                && IsOnBrigde()
                && !(velocityAdjust.y < 0)
                && collider.tag == "Brigde Brick"
                && collider.gameObject.GetComponent<BrickBrigde>().currentColor == BrickColor.COLOR0
            )
            {
                rb.velocity = Vector3.zero;
                return;
            }

            rb.velocity = velocityAdjust;
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
