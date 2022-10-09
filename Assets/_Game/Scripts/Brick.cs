using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BRICK_COLOR
{
    GREEN,
    RED,
    YELLOW,
    BLUE
}

public class Brick : MonoBehaviour
{
    public BRICK_COLOR color;

    // Start is called before the first frame update
    void Start() { }

    public void OnInit(BRICK_COLOR brickColor, Vector3 position)
    {
        color = brickColor;
        transform.position = position;
    }

    public void OnDespawn()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() { }
}
