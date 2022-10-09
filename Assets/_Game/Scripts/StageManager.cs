using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] listBrickPosition;

    [SerializeField]
    private GameObject brickPrefab;

    public int brickAmount;
    public int playerAmount;

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

        // Brick amount per player
        int brickPerPlayer = brickAmount / playerAmount;
        Debug.Log("brickPerPlayer " + brickPerPlayer);
        Debug.Log("playerAmount " + playerAmount);

        // Set color for brick of player
        for (int i = 0; i < playerAmount; i++)
        {
            Debug.Log("i loop " + i);
            for (int j = i * brickPerPlayer; j < brickPerPlayer * (i + 1); j++)
            {
                Debug.Log("Generate brick number " + j);
                GameObject brickObject = Instantiate(
                    brickPrefab,
                    Vector3.zero,
                    Quaternion.identity
                );
                brickObject.SetActive(true);
                brickObject.transform.SetParent(transform);
                brickObject
                    .GetComponent<Brick>()
                    .OnInit((BRICK_COLOR)i, listBrickPosition[j].position);
            }
        }
    }

    // Update is called once per frame
    void Update() { }
}
