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
    public Animator anim;

    [SerializeField]
    public float speed;

    public RaycastHit groundHit;

    public LayerMask layerMask;

    public bool isCanMove = true;

    public int amountBrickdivided;

    public Stage currentStage;

    private string currentAnimName;

    public void OnInit(BrickColor color)
    {
        GameManager.Instance.playersInGame.Add(this);
        SetColorTarget(color);
        collisionSensor.OnInit();
        brickHolder.OnInit();
        checkBrickBrigde.GetComponent<CheckBrickBrigde>().OnInit();
    }

    public void SetPositionPlayer(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void SetColorTarget(BrickColor color)
    {
        colorTarget = color;
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
}
