using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBrigde : MonoBehaviour
{
    public BrickColor color;
    private Renderer rendererComp;
    private float colorAlpha;

    // Start is called before the first frame update
    void Start()
    {
        rendererComp = transform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() { }

    public void SetColorBrick(BrickColor brickColor)
    {
        color = brickColor;
        rendererComp.material = GameManager.Instance.listColor[(int)color];
    }
}
