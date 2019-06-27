using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour, Movable {

    private float _racketSpeed; 

	// Use this for initialization
	void Start () {
        InitRacket();
	}
	
	// Update is called once per frame
	void Update () {
        MovementController();
	}

    private void InitRacket()
    {
        _racketSpeed = 7.5f;
    }

    public void MovementController()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector3.right * horizontalInput * _racketSpeed;
    }
}
