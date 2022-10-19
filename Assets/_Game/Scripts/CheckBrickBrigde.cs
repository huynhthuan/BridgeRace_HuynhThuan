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

    // Update is called once per frame
    void Update() { }

    private void FixedUpdate()
    {
        RaycastHit brickBrigdeHit;

        if (Physics.Raycast(transform.position, Vector3.forward, out brickBrigdeHit, 1f, layerMask))
        {
            Debug.Log("brickBrigdeHit.collider.tag " + brickBrigdeHit.collider.tag);
            if (brickBrigdeHit.collider.tag == "Brigde Brick")
            {
                Debug.DrawRay(
                    transform.position,
                    Vector3.forward * brickBrigdeHit.distance,
                    Color.red
                );

                BrickBrigde brickbrigdeComp = brickBrigdeHit.collider.GetComponent<BrickBrigde>();

                if (brickbrigdeComp.color != playerColor && brickHolderComp.brickAmount == 0)
                {
                    player.isCanMove = false;
                }
                else
                {
                    player.isCanMove = true;
                }

                if (brickHolderComp.brickAmount > 0 && brickbrigdeComp.color != playerColor)
                {
                    brickbrigdeComp.SetColorBrick(playerColor);
                    brickHolderComp.RemoveBrick();
                }
            }
        }else{
            player.isCanMove = true;
        }
    }
}
