using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : Singleton<CollisionSensor>
{
    private BrickColor playerColorTarget;
    private Character character;
    private BrickHolder brickHolderComp;

    private void Start() { }

    public void OnInit()
    {
        character = GetComponentInParent<Character>();
        playerColorTarget = character.colorTarget;
        brickHolderComp = character.brickHolder;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brick")
        {
            Brick brickComp = other.GetComponent<Brick>();

            if (brickComp.color == playerColorTarget)
            {
                brickComp.targetSelect.GetComponent<TargetSelect>().DeActiveSelect();
                brickComp.gameObject.SetActive(false);
                brickHolderComp.AddBrick(brickComp.indexOnPlane, brickComp.stageLevel);
            }
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
