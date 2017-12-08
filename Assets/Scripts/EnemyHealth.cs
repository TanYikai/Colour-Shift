using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    ColourObject enemyColour;

    bool isDead = false;
	// Use this for initialization
	void Start () {
        enemyColour = this.gameObject.GetComponent<EnemyManager>().myColour;
	}
	
	public void damage(ColourObject other)
    {
        if (other.getIsRed())
        {
            if(other.getIsBlue()){
                if (other.getIsYellow())
                    makeDead();
                else if (enemyColour.getIsYellow())
                    makeDead();
            }
            else if (other.getIsYellow())
            {
                if (enemyColour.getIsBlue())
                    makeDead();
            }
        }
        else if(other.getIsBlue())
        {
            if (other.getIsYellow())
            {
                if (enemyColour.getIsRed())
                    makeDead();
            }
            if (enemyColour.getIsYellow())
            {
                if (enemyColour.getIsRed())
                    makeDead();
            }
        }
        else if (other.getIsYellow())
        {
            if (enemyColour.getIsBlue())
            {
                if (enemyColour.getIsRed())
                    makeDead();
            }
        }
    }
    public void makeDead()
    {
        isDead = true;
        Destroy(this.gameObject);
    }
}
