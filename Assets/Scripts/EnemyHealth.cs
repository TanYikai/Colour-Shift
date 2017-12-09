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
        if (other.getIsRed())               // Bullet has red
        {
            if (other.getIsBlue())
            {          // Bullet has red and blue
                if (other.getIsYellow())    // Bullet is white
                    makeDead();
                else if (enemyColour.getIsYellow()) // Bullet is purple and Enemy has yellow
                    makeDead();
                else if (enemyColour.getIsRed() || enemyColour.getIsBlue()) // Bullet is purple and enemy has Red or Blue and no Yellow
                {
                    enemyColour.isRed = true;
                    enemyColour.isBlue = true;
                    this.gameObject.GetComponent<EnemyManager>().UpdateCol();
                }

            }
            else if (other.getIsYellow())   // Bullet is orange
            {
                if (enemyColour.getIsBlue())    // Enemy has blue
                    makeDead();
                else if (enemyColour.getIsRed() || enemyColour.getIsYellow()) // Bullet is orange and enemy has Red or Yellow but no blue
                {
                    enemyColour.isRed = true;
                    enemyColour.isYellow = true;
                    this.gameObject.GetComponent<EnemyManager>().UpdateCol();
                }
            }
            else // Bullet is red
            {
                if (enemyColour.getIsBlue() && enemyColour.getIsYellow())    // Enemy is green
                    makeDead();
            }


        }
        else if(other.getIsBlue())  // Bullet has no red but has blue
        {
            if (other.getIsYellow())    // Bullet is green
            {
                if (enemyColour.getIsRed()) // Enemy has red
                    makeDead();
                else if (enemyColour.getIsBlue() || enemyColour.getIsYellow()) // Bullet is green and enemy has Blue or Yellow but no red
                {
                    enemyColour.isBlue = true;
                    enemyColour.isYellow = true;
                    this.gameObject.GetComponent<EnemyManager>().UpdateCol();
                }
            }
            else if (enemyColour.getIsYellow())  // Bullet is blue and Enemy has yellow
            {
                if (enemyColour.getIsRed()) // Enemy is orange
                    makeDead();
            }

        }
        else if (other.getIsYellow())   // Bullet is yellow
        {   
            if (enemyColour.getIsBlue())    // Enemy has blue
            {
                if (enemyColour.getIsRed()) // Enemy is purple
                    makeDead();
            }
        }
    }
    public void makeDead()
    {
        isDead = true;
        SFXManager.PlaySound("EnemyDamaged");
        Destroy(this.gameObject);
    }
}
