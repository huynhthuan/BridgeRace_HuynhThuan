using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (
            Physics.Raycast(
                transform.position,
                transform.TransformDirection(Vector3.down),
                out hit,
                Mathf.Infinity
            )
        )
        {
            Debug.DrawRay(
                transform.position,
                transform.TransformDirection(Vector3.down) * hit.distance,
                Color.yellow
            );

            GameObject hitGameObject = hit.collider.gameObject;

            if (hitGameObject.tag == "Brick")
            {
                Brick brickComp = hitGameObject.GetComponent<Brick>();
                if (brickComp.color == GameManager.Instance.playerColorTarget)
                {
                    Destroy(hitGameObject);
                    BrickHolder.Instance.AddBrick();
                }
            }
        }
        else
        {
            Debug.DrawRay(
                transform.position,
                transform.TransformDirection(Vector3.down) * 1000,
                Color.white
            );
        }
    }
}
