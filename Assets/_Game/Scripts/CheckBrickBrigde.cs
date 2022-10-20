using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBrickBrigde : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    private Character character;
    private Player player;
    private BrickHolder brickHolderComp;

    BrickColor playerColor;

    // Start is called before the first frame update
    void Start() { }

    public void OnInit()
    {
        character = GetComponentInParent<Character>();
        player = GetComponentInParent<Player>();
        playerColor = character.colorTarget;
        brickHolderComp = character.brickHolder;
    }

    private void Update()
    {
        RaycastHit brickBrigdeHit;

        Debug.DrawRay(transform.position, Vector3.down * 2f, Color.black);

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

            if (player != null)
            {
                if (
                    brickbrigdeComp.color != playerColor
                    && brickHolderComp.brickAmount == 0
                    && player.velocityAdjust.y == 0
                )
                {
                    player.isCanMove = false;
                }
                else
                {
                    player.isCanMove = true;
                }
            }
        }
        else
        {
            if (player != null)
            {
                player.isCanMove = true;
            }
        }
    }
}
