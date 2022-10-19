using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBrickBrigde : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    private Player player;
    private BrickHolder brickHolderComp;

    BrickColor playerColor;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        playerColor = player.brickColorTarget;
        brickHolderComp = player.brickHolder;
    }

    private void Update()
    {
        RaycastHit brickBrigdeHit;

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
            Debug.DrawRay(transform.position, Vector3.down * brickBrigdeHit.distance, Color.black);

            BrickBrigde brickbrigdeComp = brickBrigdeHit.collider.GetComponent<BrickBrigde>();

            if (brickHolderComp.brickAmount > 0 && brickbrigdeComp.color != playerColor)
            {
                brickbrigdeComp.SetColorBrick(playerColor);
                brickHolderComp.RemoveBrick();
            }

            if (
                (
                    player.velocityAdjust.y == 0
                    || (
                        player.velocityAdjust.y == 0
                        && (player.velocityAdjust.x <= 0 && player.velocityAdjust.z >= 0)
                    )
                    || (
                        player.velocityAdjust.y == 0
                        && (player.velocityAdjust.x >= 0 && player.velocityAdjust.z >= 0)
                    )
                )
                && brickbrigdeComp.color != playerColor
                && brickHolderComp.brickAmount == 0
            )
            {
                player.isCanMove = false;
            }
            else
            {
                player.isCanMove = true;
            }
        }
        else
        {
            player.isCanMove = true;
        }
    }
}
