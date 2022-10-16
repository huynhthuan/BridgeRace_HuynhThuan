using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : Singleton<StageManager>
{
    [SerializeField]
    private Transform[] listBrickPosition;

    [SerializeField]
    private GameObject brickPrefab;

    [SerializeField]
    public Transform planBrick;

    private int brickAmount;
    private int playerAmount;
    private int brickPerPlayer;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        brickAmount = listBrickPosition.Length;
        playerAmount = GameManager.Instance.CountPlayer();
        brickPerPlayer = brickAmount / playerAmount;

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
                brickObject.transform.SetParent(planBrick.transform);
                Brick brickComponent = brickObject.GetComponent<Brick>();

                brickComponent.OnInit((BrickColor)(i + 1), listBrickPosition[j].position, j);
            }
        }
    }

    public void ShufferListBrickPosition()
    {
        listBrickPosition = listBrickPosition.OrderBy(x => Random.Range(0, brickAmount)).ToArray();
    }

    public Transform GetBrickObjectByIndex(int index)
    {
        return planBrick.GetChild(index);
    }

    // Update is called once per frame
    void Update() { }
}
