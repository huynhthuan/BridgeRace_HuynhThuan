using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] listBrickPosition;

    [SerializeField]
    private GameObject brickPrefab;

    private int brickAmount;
    private int playerAmount;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        brickAmount = listBrickPosition.Length;
        playerAmount = GameManager.Instance.CountPlayer();

        GenerateBrickPlan(brickAmount, playerAmount);
    }

    public void GenerateBrickPlan(int brickAmount, int playerAmount)
    {
        if (brickAmount == 0)
        {
            return;
        }

        // Random position list brick
        ShufferListBrickPosition();

        // Brick amount per player
        int brickPerPlayer = brickAmount / playerAmount;
        // Debug.Log("brickPerPlayer " + brickPerPlayer);
        // Debug.Log("playerAmount " + playerAmount);

        // Set color for brick of player
        for (int i = 0; i < playerAmount; i++)
        {
            // Debug.Log("i loop " + i);
            for (int j = i * brickPerPlayer; j < brickPerPlayer * (i + 1); j++)
            {
                // Debug.Log("Generate brick number " + j);
                GameObject brickObject = Instantiate(
                    brickPrefab,
                    Vector3.zero,
                    Quaternion.identity
                );
                brickObject.SetActive(true);
                brickObject.transform.SetParent(transform);
                Brick brickComponent = brickObject.GetComponent<Brick>();

                brickComponent.OnInit((BrickColor)i, listBrickPosition[j].position);
            }
        }
    }

    public void ShufferListBrickPosition()
    {
        listBrickPosition = listBrickPosition.OrderBy(x => Random.Range(0, brickAmount)).ToArray();
    }

    // Update is called once per frame
    void Update() { }
}
