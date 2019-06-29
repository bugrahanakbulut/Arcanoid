﻿using System.Collections;
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

    private float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    { 
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            other.gameObject.GetComponent<Block>().DoDamage();
        }

        else if (other.gameObject.tag == "Racket")
        {
            float factor = HitFactor(transform.position, 
                                     other.transform.position, 
                                     other.collider.bounds.size.x);

            Vector2 dir = new Vector2(factor, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * _ballSpeed;
        }
    }

    public void MovementController()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.up * _ballSpeed;
    }


}
