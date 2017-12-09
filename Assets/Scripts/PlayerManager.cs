using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float defaultSpeed;
    public float defaultJump;
    public float maxRange;
    private float speed;
    public int lives;
    public float fireRate;
    public float nextFire;

    public bool isJumping = false;
    private bool facingRight = true;

    public Transform gunTip;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    private ColourObject playerCol;

    private bool invulnerable = false;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerCol = new ColourObject(true, false, false);
        anim = this.GetComponent<Animator>();
    }


    void Update()
    {
        // move right
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -defaultSpeed;
            anim.SetInteger("State", 1); // run

            if (facingRight)
            {
                Flip();
            }
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
            anim.SetInteger("State", 1); // run

            if (!facingRight)
            {
                Flip();
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (speed != -defaultSpeed)
                speed = 0;

        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isJumping && rb.velocity.y >= -0.1f)
            {
                isJumping = true;
                anim.SetTrigger("isJumping");
                rb.AddForce(new Vector2(rb.velocity.x, defaultJump));
            }
        }

        MovePlayer(speed);

        if (Input.GetKey(KeyCode.X))
        {
            Extract();
        }

        if (Input.GetKey(KeyCode.Z))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PaintMyself();
        }

    }

    void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector3(playerSpeed, rb.velocity.y, 0);

        if (playerSpeed == 0)
            anim.SetInteger("State", 0); // idle

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

    void Extract()
    {

        if (PaintManager.instance.getStackSize() == 5)
        {
            return;
        }

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            RaycastHit2D hit = new RaycastHit2D();
            Vector3 dirRay;
            if (facingRight)
            {
                dirRay = Vector3.right;
            }
            else
            {
                dirRay = Vector3.left;
            }
            Debug.DrawRay(new Vector2(gunTip.position.x+0.75f * dirRay.x, gunTip.position.y+0.75f), dirRay);
            hit = Physics2D.Raycast(new Vector2(gunTip.position.x + 0.75f * dirRay.x, gunTip.position.y + 0.75f), dirRay);

            if (hit)
            {
                if (hit.collider.tag == "KEY")
                {
                    if (hit.collider.GetComponent<KeyManager>().canGive())
                        PaintManager.instance.pushToStack(hit.collider.GetComponent<KeyManager>().Extract());
                }
                else if (hit.collider.tag == "MONSTER")
                {
                    PaintManager.instance.pushToStack(hit.collider.GetComponent<EnemyManager>().myColour);
                    hit.collider.GetComponent<EnemyHealth>().makeDead();
                }
                SFXManager.PlaySound("PowerUp");
            }
        }

    }

    void Shoot()
    {
        anim.SetTrigger("isShooting");


        GameObject bullet;
        if (PaintManager.instance.getStackSize() > 0)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;


                if (facingRight)
                {
                    bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else
                {
                    bullet = Instantiate(bulletPrefab, gunTip.position + new Vector3(1f,1.5f,0), Quaternion.Euler(new Vector3(0, 0, 180f)));
                }

                bullet.GetComponent<BulletManager>().bulletCol = PaintManager.instance.popFromStack();
                SFXManager.PlaySound("GunShot");
            }
        }
    }

    void PaintMyself()
    {
        if (PaintManager.instance.getStackSize() > 0)
        {
            if (Time.time > nextFire)
            {
                if (PaintManager.instance.getStackSize() > 0)
                {
                    playerCol = PaintManager.instance.popFromStack();
                    if (playerCol.colourName().Equals("Red"))
                    {
                        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Man/Red/redcontroller");
                    }
                    else if (playerCol.colourName().Equals("Blue"))
                    {
                        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Man/Blue/bluecontroller");

                    }
                    else if (playerCol.colourName().Equals("Yellow"))
                    {
                        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Man/Yellow/yellowcontroller");

                    }
                    else if (playerCol.colourName().Equals("Black"))
                    {
                        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Man/Black/blackcontroller");
                    }
                    else if (playerCol.colourName().Equals("White"))
                    {
                        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Man/White/whitecontroller");
                    }
                    else if (playerCol.colourName().Equals("Purple"))
                    {
                        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Man/Purple/purplecontroller");
                    }
                    else if (playerCol.colourName().Equals("Orange"))
                    {
                        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Man/Orange/orangecontroller");
                    }
                    else if (playerCol.colourName().Equals("Green"))
                    {
                        anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Man/Green/greencontroller");
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D hit;
        if (collision.gameObject.tag == "GROUND" || collision.gameObject.tag == "KEY")
        {
            hit = Physics2D.Raycast(this.transform.position - new Vector3(1f, 0, 0), Vector3.down, 1.5f);
            if (hit && (hit.collider.tag == "GROUND" || hit.collider.tag == "KEY" || hit.collider.tag == "GATE"))
            {
                isJumping = false;
            }
        }
        else if (collision.gameObject.tag == "BULLET")
        {
            // Do Bullet stuff
        }
        else if (collision.gameObject.tag == "MONSTER" && !invulnerable)
        {
            hit = Physics2D.Raycast(this.transform.position, Vector3.down, 0.1f);
            if (hit && hit.collider.tag == "MONSTER")
            {
                isJumping = false;
            }

            lives--;
            UIManager.instance.breakHeart();
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

    void OnCollisionStay2D(Collision2D collision)
    {
        if (isJumping)
        {
            if (collision.gameObject.tag == "GROUND" || collision.gameObject.tag == "KEY" || collision.gameObject.tag == "GATE")
            {
                if (rb.velocity.y == 0)
                {
                    isJumping = false;
                }
            }
            else if (collision.gameObject.tag == "MONSTER" && !invulnerable)
            {
                lives--;
                UIManager.instance.breakHeart();
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
        yield return new WaitForSecondsRealtime(1);
        invulnerable = false;
        this.gameObject.layer = 0;
    }
}
    