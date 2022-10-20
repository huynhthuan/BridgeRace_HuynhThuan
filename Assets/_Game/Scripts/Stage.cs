using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private Transform[] listBrickPosition;

    [SerializeField]
    public Transform planBrick;

    [SerializeField]
    public int stageLevel;

    private GameObject brickPrefab;
    private LevelManager levelManager;
    private int playerAmount;
    private int brickTotal;
    public int brickPerPlayer;
    public List<Character> playerInStage;

    public void OnInit()
    {
        levelManager = LevelManager.Instance;
        brickPrefab = levelManager.brickPrefab;

        brickTotal = listBrickPosition.Length;
        playerAmount = GameManager.Instance.CountPlayer();
        brickPerPlayer = brickTotal / playerAmount;

        // Debug.Log("BrickTotal stage " + stageLevel + ": " + brickTotal);
        // Debug.Log("Player amount stage " + stageLevel + ": " + playerAmount);
        // Debug.Log("Brick per player stage " + stageLevel + ": " + brickPerPlayer);
        GenerateBrickPlan();
    }

    public void GenerateBrickPlan()
    {
        Debug.Log("Oninit stage " + stageLevel);

        if (brickTotal == 0)
        {
            return;
        }

        // Random position list brick
        ShufferListBrickPosition();

        // Generate brick color
        for (int i = 0; i < playerAmount; i++)
        {
            // Debug.Log("i loop " + i);
            for (int j = i * brickPerPlayer; j < brickPerPlayer * (i + 1); j++)
            {
                // Debug.Log("Generate brick number " + j);
                GameObject brickObject = Instantiate(
                    brickPrefab,
                    Vector3.zero,
                    Quaternion.identity,
                    planBrick
                );
                brickObject.SetActive(false);
                Brick brickComponent = brickObject.GetComponent<Brick>();

                // Debug.Log("Brick init stage position " + listBrickPosition[j].position);

                brickComponent.OnInit((BrickColor)(i + 1), listBrickPosition[j].position, j);
            }
        }

        Debug.Log("Init stage done");
    }

    public void ShufferListBrickPosition()
    {
        Debug.Log("Random position brick");
        listBrickPosition = listBrickPosition.OrderBy(x => Random.Range(0, brickTotal)).ToArray();
    }

    public void EnableBrickColor(BrickColor color)
    {
        foreach (Transform child in planBrick)
        {
            Brick brickComp = child.GetComponent<Brick>();

            if (brickComp.color == color)
            {
                brickComp.gameObject.SetActive(true);
            }
        }
    }

    public Transform GetBrickObjectByIndex(int index)
    {
        return planBrick.GetChild(index);
    }
}
