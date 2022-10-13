using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBrigde : MonoBehaviour
{
    public BrickColor currentColor;
    private Renderer rendererComp;

    // Start is called before the first frame update
    void Start()
    {
        rendererComp = transform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() { }

    private void SetColorBrick(BrickColor brickColor)
    {
        currentColor = brickColor;
        rendererComp.material = GameManager.Instance.listColor[(int)currentColor];
    }
}
