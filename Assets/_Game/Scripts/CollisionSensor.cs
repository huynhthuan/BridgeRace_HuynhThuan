using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : Singleton<CollisionSensor>
{
    private BrickColor playerColorTarget;
    private Character player;
    private BrickHolder brickHolderComp;

    private void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        player = GetComponentInParent<Character>();
        playerColorTarget = player.colorTarget;
        brickHolderComp = player.brickHolder;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brick")
        {
            Brick brickComp = other.GetComponent<Brick>();
            if (brickComp.color == playerColorTarget)
            {
                other.gameObject.SetActive(false);
                brickHolderComp.AddBrick(brickComp.indexOnPlane, brickComp.stageLevel);
            }
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
