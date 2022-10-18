using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : Singleton<CollisionSensor>
{
    BrickColor playerColor;

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
            if (brickComp.color == playerColor)
            {
                other.gameObject.SetActive(false);
                brickHolderComp.AddBrick(brickComp.indexOnPlane);
            }
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
