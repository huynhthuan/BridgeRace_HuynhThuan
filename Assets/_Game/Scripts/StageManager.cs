using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : MonoBehaviour
{
    private LevelController levelController;

    [SerializeField]
    private Transform[] listBrickPosition;
    private GameObject brickPrefab;
    private Transform planBrick;

    [SerializeField]
    public List<BrickColor> colorInStage;

    public int brickAmount;
    private int playerAmount;
    private int brickPerPlayer;

    [SerializeField]
    private int level;

    // Start is called before the first frame update
    void Start() { }

    public void OnInit()
    {
        levelController = GetComponentInParent<LevelController>();

        brickPrefab = levelController.brickPrefab;
        planBrick = levelController.planBrick;
        brickAmount = listBrickPosition.Length;
        playerAmount = GameManager.Instance.CountPlayer();
        brickPerPlayer = brickAmount / playerAmount;

        GenerateBrickPlan();
    }

    public void GenerateBrickPlan()
    {
        if (brickAmount == 0)
        {
            return;
        }

        // Random position list brick
        ShufferListBrickPosition();

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
                brickObject.SetActive(false);
                brickObject.transform.SetParent(planBrick.transform);
                Brick brickComponent = brickObject.GetComponent<Brick>();

                brickComponent.OnInit((BrickColor)(i + 1), listBrickPosition[j].position, j);
            }
        }

        Debug.Log("Init stage " + level + " done");
    }

    public void ShufferListBrickPosition()
    {
        listBrickPosition = listBrickPosition.OrderBy(x => Random.Range(0, brickAmount)).ToArray();
    }

    public void AddColorStage(BrickColor color, int stageLevel)
    {
        colorInStage.Add(color);
        EnableBrickColor(color, stageLevel);
    }

    public void EnableBrickColor(BrickColor colorEnable, int stageLevelColorEnable)
    {
        foreach (Transform child in planBrick)
        {
            Brick brickComp = child.GetComponent<Brick>();

            if (brickComp.color == colorEnable && brickComp.stageLevel == stageLevelColorEnable)
            {
                brickComp.gameObject.SetActive(true);
            }
        }
    }
}
