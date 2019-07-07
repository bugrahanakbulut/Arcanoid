using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IBlock {

    private int _health;

    // Use this for initialization
    void Start()
    {
        InitBlock();
    }


    public void InitBlock()
    {
        _health = 1;
    }


    public void DoDamage()
    {
        _health -= 1;
        if (_health == 0)
        {
            NotifyLevelControllerImGone();
            Destroy(this.gameObject);
        }
    }

    void NotifyLevelControllerImGone()
    {
        GameObject controllers = GameObject.Find("Controllers");
        if (controllers != null)
        {
            LevelController levelController = controllers.GetComponent<LevelController>();
            levelController.CheckIsLevelCompleted();
        }
    }
}
