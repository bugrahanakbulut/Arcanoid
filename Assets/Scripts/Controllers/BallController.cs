using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour, Movable {

    private float _ballSpeed;

	// Use this for initialization
	void Start () {
        InitBall();
        MovementController();
	}
	
    void InitBall()
    {
        _ballSpeed = 10.0f;
    }

    public void MovementController()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.up * _ballSpeed;
    }
}
