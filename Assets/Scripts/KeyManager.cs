using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {

    public bool isRed;
    public bool isBlue;
    public bool isYellow;
    public int count;

    private ColourObject keyCol;

	// Use this for initialization
	void Start () {
        keyCol = new ColourObject(isRed, isBlue, isYellow);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public ColourObject Extract()
    {

        if (count > 0)
        {
            count--;
        }

        if (count == 0)
        {
            this.GetComponent<Renderer>().material.color = Color.black;
        }

        return keyCol;
    }

    public bool canGive() {
        return !(count == 0);
    }

}
