using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private float _ballSpeed;

	// Use this for initialization
	void Start () {
        InitBall();
        GetComponent<Rigidbody2D>().velocity = Vector3.up * _ballSpeed;
	}
	
    void InitBall()
    {
        _ballSpeed = 10.0f;
    }
	
}
