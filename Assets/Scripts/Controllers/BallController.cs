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

    void HitBottomBorder()
    {
        GameObject controllers = GameObject.Find("Controllers");
        if (controllers != null)
        {
            Transform gameControllerGameObject = controllers.transform.Find("GameController");
            if (gameControllerGameObject != null)
            {
                GameController gameController = gameControllerGameObject.GetComponent<GameController>();
                if (gameController != null)
                {
                    gameController.BallOutOfMap();
                    Destroy(this.gameObject);
                }
            }
        }
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
        else if (other.gameObject.name == "Bottom Border")
        {
            HitBottomBorder();
        }
    }

    public void MovementController()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.up * _ballSpeed;
    }

    public void SetSpeed(float speed)
    {
        _ballSpeed = speed;
    }

}
