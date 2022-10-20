using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBrickBrigde : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    private Character player;
    private BrickHolder brickHolderComp;

    BrickColor playerColor;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Character>();
        playerColor = player.colorTarget;
        brickHolderComp = player.brickHolder;
    }

    private void Update()
    {
        RaycastHit brickBrigdeHit;

        Debug.DrawRay(transform.position, Vector3.down * Mathf.Infinity, Color.black);

        if (
            Physics.Raycast(
                transform.position,
                Vector3.down,
                out brickBrigdeHit,
                Mathf.Infinity,
                layerMask
            )
        )
        {
            BrickBrigde brickbrigdeComp = brickBrigdeHit.collider.GetComponent<BrickBrigde>();

            if (brickHolderComp.brickAmount > 0 && brickbrigdeComp.color != playerColor)
            {
                brickbrigdeComp.SetColorBrick(playerColor);
                brickHolderComp.RemoveBrick();
            }

            // if (
            //     (
            //         player.velocityAdjust.y == 0
            //         || (
            //             player.velocityAdjust.y == 0
            //             && (player.velocityAdjust.x <= 0 && player.velocityAdjust.z >= 0)
            //         )
            //         || (
            //             player.velocityAdjust.y == 0
            //             && (player.velocityAdjust.x >= 0 && player.velocityAdjust.z >= 0)
            //         )
            //     )
            //     && brickbrigdeComp.color != playerColor
            //     && brickbrigdeComp.color == BrickColor.COLOR0
            //     && brickHolderComp.brickAmount == 0
            // )
            // {
            //     player.isCanMove = false;
            // }
            // else
            // {
            //     player.isCanMove = true;
            // }
        }
        else
        {
            player.isCanMove = true;
        }
    }
}
