using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : Singleton<CollisionSensor>
{
    BrickColor playerColor;
    private Collider currentCollider;

    private void Start()
    {
        playerColor = GameManager.Instance.playerColorTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentCollider = other;
        if (other.tag == "Brick")
        {
            Brick brickComp = other.GetComponent<Brick>();
            if (brickComp.color == playerColor)
            {
                other.gameObject.SetActive(false);
                BrickHolder.Instance.AddBrick(brickComp.indexOnPlane);
            }
        }

        if (other.tag == "Brigde Brick")
        {
            BrickBrigde brickComp = other.GetComponent<BrickBrigde>();

            if (brickComp.currentColor != playerColor)
            {
                BrickBrigde brickbrigdeComp = other.GetComponent<BrickBrigde>();
                brickbrigdeComp.SetColorBrick(playerColor);
            }
        }
    }

    public Collider GetCurrentCollider()
    {
        return currentCollider;
    }
}
