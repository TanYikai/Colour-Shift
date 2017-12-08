using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public float defaultSpeed;
    public float defaultJump;
    public float maxRange;
    private float speed;
    public int lives = 3;

    public bool isJumping;
    private bool facingRight;

    public Transform gunTip;
    public Rigidbody2D rb;
    public GameObject bullet;
    private ColourObject playerCol;
    
    


    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        playerCol = new ColourObject(true,false,false);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (facingRight)
            {
                facingRight = false;
                Flip();
            }
            speed = -defaultSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!facingRight)
            {
                facingRight = true;
                Flip();
            }
            speed = defaultSpeed;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //ButtonMovement.isJumping = true;
            isJumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, defaultJump));
            //anim.SetInteger("State", 2);
        }

        // Left mouse button
        /*if (Input.GetMouseButton(0))
        {
            Extract();
        }*/

        if (Input.GetMouseButton(1))
        {
            Shoot();
        }

        MovePlayer(speed);
        
    }

    void MovePlayer(float playerSpeed) {
        //rb.velocity = new Vector3(playerSpeed, rb.velocity.y, 0);
    }

    void Flip()
    {
        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    void Extract() {

        float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        float currPosX = this.GetComponent<Transform>().position.x;
        float currPosY = this.GetComponent<Transform>().position.y;

        Collider[] colliders = Physics.OverlapSphere(new Vector3(mouseX, mouseY, 0), 0.1f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.CompareTag("KEY"))
            {
                if (Mathf.Abs(mouseX - currPosX) < maxRange && Mathf.Abs(mouseY - currPosY) < maxRange)
                {
                    //PaintManager.instance.pushToStack(colliders[i].gameObject.GetComponent<KeyManager>().ReturnCol());

                }
            }
            else if (colliders[i].gameObject.CompareTag("WALL"))
            {
                if (Mathf.Abs(mouseX - currPosX) < maxRange && Mathf.Abs(mouseY - currPosY) < maxRange)
                {
                    //PaintManager.instance.pushToStack(colliders[i].gameObject.GetComponent<WallManager>().ReturnCol());
                }
            }
            else if (colliders[i].gameObject.CompareTag("ENEMY"))
            {
                if (Mathf.Abs(mouseX - currPosX) < maxRange && Mathf.Abs(mouseY - currPosY) < maxRange) {
                
                    //PaintManager.instance.pushToStack(colliders[i].gameObject.GetComponent<EnemyManager>().ReturnCol());
                }
            }
        }
    }

    void Shoot() {

        if (facingRight)
        {
            Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else if (!facingRight)
        {
            Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
        }
    }

 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND" && rb.velocity.y == 0)
        {
            //ButtonMovement.isJumping = false;  // landed
            isJumping = false;
            speed = 0;
            //anim.SetInteger("State", 1);
        }
        else if (collision.gameObject.tag == "BULLET")
        {
            // Do Bullet stuff
        }
 
    }
}
