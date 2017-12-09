using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public float bulletSpeed;
    public float lifeTime;
    Rigidbody2D myRB;

    public bool facingRight;
    public ColourObject bulletCol;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        

        myRB = GetComponent<Rigidbody2D>();

        if (transform.localRotation.z > 0)
            myRB.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        else
            myRB.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);

        if (bulletCol.colourName().Equals("Red"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Bullets/Blue/bullets_8");
        }
        else if (bulletCol.colourName().Equals("Blue"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Bullets/Blue/bullets_0");

        }
        else if (bulletCol.colourName().Equals("Yellow"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Bullets/Yellow/bullets_8");

        }
        else if (bulletCol.colourName().Equals("Orange"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Bullets/Orange/orange");

        }
        else if (bulletCol.colourName().Equals("Purple"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Bullets/Purple/purple");

        }
        else if (bulletCol.colourName().Equals("Green"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Bullets/Green/green");

        }
        else if (bulletCol.colourName().Equals("White"))
        {
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Bullets/White/white");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        Destroy(this.gameObject, lifeTime);
    }

    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND" || collision.gameObject.tag == "GATE")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "MONSTER")
        {
            //Debug.Log("Blue" + bulletCol.getIsBlue() + " Red" + bulletCol.getIsRed() + " Yellow" + bulletCol.getIsYellow());
            collision.gameObject.GetComponent<EnemyHealth>().damage(bulletCol);
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND" || collision.gameObject.tag == "GATE")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "MONSTER")
        {
            //Debug.Log("Blue" + bulletCol.getIsBlue() + " Red" + bulletCol.getIsRed() + " Yellow" + bulletCol.getIsYellow());
            collision.gameObject.GetComponent<EnemyHealth>().damage(bulletCol);
            Destroy(this.gameObject);
        }
    }
   
}
