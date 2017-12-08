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
    private bool facingRight = true;

    public Transform gunTip;
    public Rigidbody2D rb;
    public GameObject bullet;
    private ColourObject playerCol;

    private bool invulnerable = false;



    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        playerCol = new ColourObject(true,false,false);
	}

    private void FixedUpdate()
    {


        // Left mouse button
        if (Input.GetKey(KeyCode.X))
        {
            Extract();
        }

        if (Input.GetKey(KeyCode.Z))
        {
            Shoot();
        }
    }

    void Update()
    {
                       // move right, stop
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -defaultSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (speed != defaultSpeed)
            speed = 0;
        }

        // move left, stop
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = defaultSpeed;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (speed != -defaultSpeed)
                speed = 0;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isJumping)
            {
                isJumping = true;
                rb.AddForce(new Vector2(rb.velocity.x, defaultJump));
            }
        }

        MovePlayer(speed);

    }

    void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector3(playerSpeed, rb.velocity.y, 0);

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

        Vector3 dirRay;

        RaycastHit2D hit = new RaycastHit2D();
        if (facingRight)
        {
            dirRay = Vector3.right;
        }
        else
        {
            dirRay = Vector3.left;
        }

        Ray2D extRay = new Ray2D(new Vector2(this.transform.position.x, this.transform.position.y), dirRay);
        hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), Vector3.forward, maxRange, 1);

        PaintManager.instance.pushToStack(hit.collider.GetComponent<KeyManager>().ReturnCol());
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
        if (collision.gameObject.tag == "GROUND" && rb.velocity.y < 0)
        {
            isJumping = false;
            //speed = 0;
        }
        else if (collision.gameObject.tag == "BULLET")
        {
            // Do Bullet stuff
        }
        else if (collision.gameObject.tag == "MONSTER")
        {
            lives--;
            if (lives == 0)
            {
                makeDead();
            }
            /*
           if (!facingRight)
               rb.AddForceAtPosition(new Vector2(1.5f, 0.2f), this.gameObject.GetComponent<Transform>().position, ForceMode2D.Impulse);
           else
               rb.AddForceAtPosition(new Vector2(-1.5f, 0.2f), this.gameObject.GetComponent<Transform>().position, ForceMode2D.Impulse);
           */
            StartCoroutine(InvunerablePeriod());
        }
    }
    void makeDead()
    {
        //Dead Stuff
        Destroy(this.gameObject);
    }

	/**
	 * Returns the ColourObject of the player
	 */
	public ColourObject getPlayerColour()
	{
		return this.playerCol;
	}
    IEnumerator InvunerablePeriod()
    {
        invulnerable = true;
        this.gameObject.layer = 9;
        //Add animation 
        yield return new WaitForSecondsRealtime(10);
        invulnerable = false;
        this.gameObject.layer = 0;
    }
}
