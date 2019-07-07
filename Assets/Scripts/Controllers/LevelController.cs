using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _blocks;

    private int _currentLevel = 1;

    public void CreateLevel()
    {
        if (_currentLevel == 1)
        {
            InitLevelOneBlocks();
        }
        else if (_currentLevel == 2)
        {
            InitLevelTwoBlocks();
        }
    }

    public void CheckIsLevelCompleted()
    {
        GameObject destroyableBlocks = GameObject.Find("Destroyable Blocks");
        if (destroyableBlocks != null)
        {
            Debug.Log(destroyableBlocks.transform.childCount);
            bool levelIsCompleted = (destroyableBlocks.transform.childCount == 1);
            if (levelIsCompleted)
            {
                CreateNewLevel();
            }
        }
    }

    void CreateNewLevel()
    {
        _currentLevel++;
        GameController gameController = this.GetComponent<GameController>();
        if (gameController != null)
        {
            gameController.RespawnBallOnRacket();
        }
        CreateLevel();
    }

    void CreateBlockLine(GameObject block, float x_pos, float y_pos)
    {
        while (x_pos < +6.0f)
        {
            GameObject instantiatedBlock = Instantiate(block, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
            x_pos += block.GetComponent<BoxCollider2D>().size.x * block.transform.localScale.x + 0.05f;
            instantiatedBlock.transform.parent = GameObject.Find("Destroyable Blocks").transform;
        }
    }

    void CreateMultipleBlockLines(GameObject block, float x_pos, float y_pos, int numberOfLines)
    {
        float x_reset_value = (float)x_pos;
        for (int i = 0; i < numberOfLines && y_pos > -1.5f; i++)
        {
            CreateBlockLine(block, x_pos, y_pos);
            y_pos -= (block.GetComponent<BoxCollider2D>().size.y * block.transform.localScale.y + 0.05f);
            x_pos = x_reset_value;
        }
    }

    void InitLevelOneBlocks()
    {
        float y_pos = 4.5f;
        float x_pos = -6.0f;
        GameObject block = _blocks[0];
        CreateBlockLine(block, x_pos, y_pos);
    }

    void InitLevelTwoBlocks()
    {
        float y_pos = 4.5f;
        float x_pos = -6.0f;
        GameObject block = _blocks[0];
        CreateMultipleBlockLines(block, x_pos, y_pos, 2);
    }
}
