using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject _racket;

    [SerializeField]
    private GameObject _ball;

    [SerializeField]
    private LevelController _levelController;

    // Use this for initialization
    void Start () {
        InitGame();
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
        _levelController.CreateLevel();
    }

    void LaunchBall()
    {
        GameObject ball = GameObject.Find("Ball(Clone)");
        ball.transform.parent = _racket.transform.parent;
        if (ball != null)
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
    public void RespawnBallOnRacket()
    {
        GameObject ball = GameObject.Find("Ball(Clone)");
        if (ball != null)
            Destroy(ball);
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

}
