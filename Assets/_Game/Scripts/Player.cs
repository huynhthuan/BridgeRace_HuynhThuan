using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField]
    public BrickColor brickColorTarget;

    [SerializeField]
    public bool onGround = false;

    [SerializeField]
    public bool onSlope = false;

    [SerializeField]
    private Transform checkGround;

    public RaycastHit groundHit;
    public RaycastHit slopeHit;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit() { }

    // Update is called once per frame
    void Update() { }

    public void SetPositionPlayer(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(checkGround.position, Vector3.down, out groundHit, Mathf.Infinity, 3))
        {
            if (groundHit.collider.tag == "Ground")
            {
                Debug.DrawRay(
                    transform.position,
                    transform.TransformDirection(Vector3.down) * groundHit.distance,
                    Color.yellow
                );

                onGround = Vector3.Distance(checkGround.position, groundHit.point) <= 0.3f;
            }
        }

        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, Mathf.Infinity, 3))
        {
            Debug.Log("slopeHit.collider.tag " + slopeHit.collider.tag);
            if (slopeHit.collider.tag == "Ground")
            {
                Debug.DrawRay(
                    transform.position,
                    transform.TransformDirection(Vector3.down) * slopeHit.distance,
                    Color.red
                );

                float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
                onSlope = angle > 0;
            }
            else
            {
                onSlope = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
      if(other.gameObject.tag == "Brigde Brick"){

      }
    }
}
