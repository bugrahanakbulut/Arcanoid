using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject _racket;

    [SerializeField]
    private GameObject _ball;

    [SerializeField]
    private GameObject[] _blocks;

    private int _currentLevel;

    // Use this for initialization
    void Start () {
        InitGame();
        InitLevelTwoBlocks();
	}

    void Update()
    {
        InputController();
    }

    void InitGame()
    {
        // Init rackets position
        GameObject racket = Instantiate(_racket, new Vector3(0, -4.3f), Quaternion.identity);
        racket.transform.parent = GameObject.Find("Game Models").transform;
        GameObject ball = Instantiate(_ball, new Vector3(0, -4.0f), Quaternion.identity);
        ball.transform.parent = GameObject.Find("Racket(Clone" +
            ")").transform;
        _currentLevel = 1;
    }

    void LaunchBall()
    {
        GameObject ball = GameObject.Find("Ball(Clone)");
        if(ball.GetComponent<Rigidbody2D>().simulated == false)
            ball.GetComponent<Rigidbody2D>().simulated = true;
    }

    void InputController()
    {
        LaunchController();
    }

    void LaunchController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
    }

    public void BallOutOfMap()
    {
        Debug.Log("Game Over or Player Losses 1 Health");
        RespawnBallOnRacket();
    }

    void RespawnBallOnRacket()
    {
        GameObject racket = GameObject.Find("Racket(Clone)");
        if (racket != null)
        {
            Vector3 spawnPos = racket.transform.position;
            spawnPos.y += 0.3f;
            GameObject newBall = Instantiate(_ball, spawnPos, Quaternion.identity);
            newBall.GetComponent<Rigidbody2D>().simulated = false;
            newBall.transform.parent = racket.transform;
        }
    }

    void CreateBlockLine(GameObject block, float x_pos, float y_pos)
    {
        while (x_pos < +8.5f)
        {
            GameObject instantiatedBlock = Instantiate(block, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
            x_pos += block.GetComponent<BoxCollider2D>().size.x * block.transform.localScale.x + 0.05f;
            instantiatedBlock.transform.parent = GameObject.Find("Blocks").transform;
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
        float x_pos = -8.5f;
        GameObject block = _blocks[0];
        CreateBlockLine(block, x_pos, y_pos);
    }

    void InitLevelTwoBlocks()
    {
        float y_pos = 4.5f;
        float x_pos = -8.5f;
        GameObject block = _blocks[0];
        CreateMultipleBlockLines(block, x_pos, y_pos, 2);
    }
}
