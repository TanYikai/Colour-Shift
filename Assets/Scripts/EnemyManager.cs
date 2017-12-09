using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public ColourObject myColour;
    Rigidbody2D myRB;
    Animator myAnim;
    Transform myTrans;

    public bool red;
    public bool blue;
    public bool yellow;

    public LayerMask enemyMask;
    bool toRight = false;
    bool changedDirection = true;
    public float changeTime = 2;
    public float speed = 1;
    public float myWidth, myHeight;

    Animator anim;

    // Use this for initialization
    void Awake () {
        myColour = new ColourObject(red, blue, yellow);
  

        myRB = this.GetComponent<Rigidbody2D>();
        myAnim = this.GetComponent<Animator>(); 
        myTrans = this.GetComponent<Transform>();
        //StartCoroutine(changeDirectionAfter(changeTime)); //Use to change direction after time instead of collision
        UpdateCol();
    }
	
	// Update is called once per fraction of sec
	void FixedUpdate () {
        /* Change Direction AfterGiven Time
         * Calls coroutine after changing direction
         
        if (!changedDirection)
        {
            StartCoroutine(changeDirectionAfter(changeTime));
        }
        */
        RaycastHit2D hit = new RaycastHit2D();
        /*Change direction with Line Cast
         */
        Vector2 lineCastPos = new Vector2(myTrans.position.x,myTrans.position.y)- new Vector2(myTrans.right.x,myTrans.right.y) * myWidth - Vector2.up * (myHeight / 2);

        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        //Cast line to check grounded
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);

        Debug.DrawLine(lineCastPos, lineCastPos - new Vector2(myTrans.right.x, myTrans.right.y) * .05f);
        //Case line to check if blocked
        hit = Physics2D.Linecast(lineCastPos, lineCastPos - new Vector2(myTrans.right.x, myTrans.right.y) * .05f, enemyMask);

        //If theres no ground, turn around. Or if I hit a wall, turn around
        if (!isGrounded || (hit.collider!=null&&hit.collider.tag!="PLAYER"))
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
            toRight = !toRight;
        }

        if (toRight)
            myRB.velocity = new Vector3(speed , myRB.velocity.y, 0);
        else
            myRB.velocity = new Vector3(-speed, myRB.velocity.y, 0);


    }
    
    IEnumerator changeDirectionAfter(float time)
    {
        changedDirection = true;
        yield return new WaitForSecondsRealtime(time);
        toRight = !toRight;
        changedDirection = false;
    }

    public void UpdateCol()
    {
        if (myColour.colourName().Equals("Red"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Monster/Red/red_move");
        }
        else if (myColour.colourName().Equals("Blue"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Monster/Blue/monster_0");

        }
        else if (myColour.colourName().Equals("Yellow"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Monster/Yellow/yellow_move");

        }
        else if (myColour.colourName().Equals("Purple"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Monster/Purple/Purple Move");
        }
        else if (myColour.colourName().Equals("Orange"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Monster/Orange/Orange_Move");
        }
        else if (myColour.colourName().Equals("Green"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Monster/Green/Green Move");
        }
    }
}
