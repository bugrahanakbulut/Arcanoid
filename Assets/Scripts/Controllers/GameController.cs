using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject racket;

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameObject block;

    // Use this for initialization
    void Start () {
        InitGameObjects();
        InitLevelOneBlocks();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitGameObjects()
    {
        // Init rackets position
        Instantiate(racket, new Vector3(0, -4.3f), Quaternion.identity);
        Instantiate(ball, new Vector3(0, -4.0f), Quaternion.identity);
    }

    void InitLevelOneBlocks()
    {
        float y_pos = 3.5f;
        float x_pos = -9.50f;
        while (x_pos < 10.0f)
        {
            Instantiate(block, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
            x_pos += 1.15f;
        }
    }

}
