﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int playerHP = 3;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void damage()
    {

        playerHP--;
        if (playerHP == 0)
        {
            makeDead();
        }
        else
        {
            //this.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(5f, 3.75f), this.GetComponent<Transform>().position, ForceMode2D.Impulse);
        }

    }
    void makeDead()
    {
        //Dead Stuff
        Destroy(this.gameObject);
    }
}
