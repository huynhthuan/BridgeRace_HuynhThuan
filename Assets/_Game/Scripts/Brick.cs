using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BRICK_COLOR
{
    COLOR1,
    COLOR2,
    COLOR3,
    COLOR4
}

public class Brick : MonoBehaviour
{
    public BRICK_COLOR color;

    private Material material;

    // Start is called before the first frame update
    void Start() { }

    public void OnInit(BRICK_COLOR brickColor, Vector3 position)
    {
        material = transform.GetComponent<MeshRenderer>().material;
        color = brickColor;
        transform.position = position;

        SetColorBrick((int)color);
    }

    public void OnDespawn()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() { }

    private void SetColorBrick(int brickColor)
    {
        material = GameManager.Instance.listColor[brickColor];
    }
}
