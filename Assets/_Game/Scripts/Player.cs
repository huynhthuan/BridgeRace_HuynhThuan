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

    [SerializeField]
    private Transform checkSlope;

    public RaycastHit groundHit;
    public RaycastHit slopeHit;

    public LayerMask layerMask;

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
        if (Physics.Raycast(checkGround.position, Vector3.down, out groundHit, Mathf.Infinity))
        {
            if (groundHit.collider.tag == "Ground")
            {
                Debug.DrawRay(
                    checkGround.position,
                    transform.TransformDirection(Vector3.down) * groundHit.distance,
                    Color.yellow
                );

                onGround = Vector3.Distance(checkGround.position, groundHit.point) <= 0.2f;
            }
        }

        if (Physics.Raycast(checkSlope.position, Vector3.down, out slopeHit, Mathf.Infinity,layerMask))
        {
            Debug.Log("slopeHit.collider.tag " + slopeHit.collider.name);

            Debug.DrawRay(
                checkSlope.position,
                transform.TransformDirection(Vector3.down) * 100f,
                Color.red
            );

            if (slopeHit.collider.tag == "Ground")
            {
                float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
                Debug.Log("Check angle " + (angle > 0));
                if (angle > 0)
                {
                    float yPos = Player.Instance.slopeHit.point.y + 1f;
                    // Debug.Log("V3 " + new Vector3(transform.position.x, yPos, transform.position.z));
                    transform.position = new Vector3(
                        transform.position.x,
                        yPos,
                        transform.position.z
                    );
                }
            }
            else
            {
                onSlope = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) { }
}
