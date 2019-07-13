using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour, Movable
{

    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        InitBuff();
    }

    // Update is called once per frame
    
    void InitBuff()
    {
        _speed = 2.0f;
    }

    public void MovementController()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector3.down * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Racket")
            this.ExecuteBuff(other.gameObject);
    }

    public abstract void ExecuteBuff(GameObject racket);
}
