﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartNewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
