using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour {

    private float _racketSpeed; 

	// Use this for initialization
	void Start () {
        InitRacket();
	}
	
	// Update is called once per frame
	void Update () {
        InputController();
	}

    private void InitRacket()
    {
        _racketSpeed = 7.5f;
    }

    void InputController()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // Vector3 movementVector = Vector3.right * horizontalInput * _racketSpeed * Time.deltaTime;
        // transform.Translate(movementVector);
        GetComponent<Rigidbody2D>().velocity = Vector3.right * horizontalInput * _racketSpeed;
    }
}
