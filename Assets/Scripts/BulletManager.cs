﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    public float bulletSpeed;
    Rigidbody2D myRB;

    private ColourObject bulletCol;

    // Use this for initialization
    void Start()
    {
        //bulletCol = PaintManager.instance.popFromStack();
        myRB = GetComponent<Rigidbody2D>();

        if (transform.localRotation.z > 0)
            myRB.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        else
            myRB.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND" || collision.gameObject.tag == "WALL")
        {
            Destroy(this);
        }
        else if (collision.gameObject.tag == "PLAYER")
        {
            // Do Bullet stuff
        }

    }
}
