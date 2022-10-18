using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickColor
{
    COLOR0,
    COLOR1,
    COLOR2,
    COLOR3,
    COLOR4
}

public class Brick : MonoBehaviour
{
    [SerializeField]
    public Transform targetSelect;

    public BrickColor color;

    private Renderer rendererComp;
    public int indexOnPlane;

    // Start is called before the first frame update
    void Start() { }

    public void OnInit(BrickColor brickColor, Vector3 position, int brickIndex)
    {
        indexOnPlane = brickIndex;
        rendererComp = transform.GetComponent<Renderer>();
        color = brickColor;
        transform.position = position;

        SetColorBrick(color);
    }

    public void OnDespawn()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() { }

    private void SetColorBrick(BrickColor brickColor)
    {
        rendererComp.material = GameManager.Instance.listColor[(int)brickColor];
    }
}
