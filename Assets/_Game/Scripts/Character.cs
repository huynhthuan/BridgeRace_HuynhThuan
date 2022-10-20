using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    public BrickColor colorTarget;

    [SerializeField]
    public Transform checkBrickBrigde;

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

    public bool isCanMove = true;

    public int amountBrickdivided;

    public Stage currentStage;

    public void OnInit(BrickColor color)
    {
        SetColorTarget(color);
    }

    public void SetPositionPlayer(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void SetColorTarget(BrickColor color)
    {
        colorTarget = color;
    }
}
