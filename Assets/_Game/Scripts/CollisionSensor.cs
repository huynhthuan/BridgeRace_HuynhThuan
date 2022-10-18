using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : Singleton<CollisionSensor>
{
    BrickColor playerColor;
    private BrickColor currentCollorColision;

    private Player player;
    private BrickHolder brickHolderComp;

    private void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        player = GetComponentInParent<Player>();
        playerColor = player.brickColorTarget;
        brickHolderComp = player.brickHolder;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brick")
        {
            Brick brickComp = other.GetComponent<Brick>();
            currentCollorColision = brickComp.color;
            if (brickComp.color == playerColor)
            {
                other.gameObject.SetActive(false);
                brickHolderComp.AddBrick(brickComp.indexOnPlane);
            }
        }

        if (other.tag == "Brigde Brick")
        {
            BrickBrigde brickbrigdeComp = other.GetComponent<BrickBrigde>();
            currentCollorColision = brickbrigdeComp.color;

            if (
                (brickHolderComp.brickAmount == 0 || brickbrigdeComp.color == playerColor)
                && !(player.rb.velocity.y < 0)
            )
            {
                player.isCanMove = false;
                return;
            }
            else
            {
                player.isCanMove = true;
            }

            brickbrigdeComp.SetColorBrick(playerColor);
            brickHolderComp.RemoveBrick();
        }
    }

    public BrickColor GetCurrentColorCollider()
    {
        return currentCollorColision;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
