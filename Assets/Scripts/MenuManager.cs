﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toGame()
    {
        SceneManager.LoadScene("Scene 1");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
