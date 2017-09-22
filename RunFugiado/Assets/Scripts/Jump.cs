using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    [Range(1, 10)]
    public float jumpVel;

    public bool MoveEnabled = true;
    public bool SlideEnabled = true;

    public bool grounded;
    public bool move;
    public float moveVel;

    public float timer;
    public bool controle;

    public float timerRun;

    public Animator anim;

    public float dieTimer;
    public Sprite dead;
	// Use this for initialization
	void Start () {
        moveVel = 1f;

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(anim.GetBool("Die") == true)
        {
            dieTimer += Time.deltaTime;
        }

        if(dieTimer > 0.5f)
        {
            anim.enabled = false;
            GetComponent<SpriteRenderer>().sprite = dead;
        }

        if(transform.position.x < -6.84f)
        {
            timerRun += Time.deltaTime;
        }

        if(timerRun > 15)
        {
            move = true;
        }

        if (transform.position.x >= -6.84f)
        {
            move = false;
            timerRun = 0;
        }

        if (move == true)// && anim.GetBool("Slide") == false && anim.GetBool("Jump") == false)
        {
            transform.Translate(moveVel * Time.deltaTime, 0, 0);
        }

        ////////////////////////// Move ////////////////////////////////
        if (MoveEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                move = true;
                if (moveVel > 0)
                {
                    moveVel *= -1;
                }
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                move = true;
                if (moveVel < 0)
                {
                    moveVel *= -1;
                }
            }

            if (Input.GetKeyUp(KeyCode.A) && moveVel < 0)
                move = false;

            if (Input.GetKeyUp(KeyCode.D) && moveVel > 0)
                move = false;

            if (move == true)// && anim.GetBool("Slide") == false && anim.GetBool("Jump") == false)
            {
                transform.Translate(moveVel * Time.deltaTime, 0, 0);
            }

            if(transform.position.x < -17 && moveVel < 0)
            {
                move = false;
            }

            if (transform.position.x > -0.7f && moveVel > 0)
            {
                move = false;
            }
        }
        ////////////////////////// JUMP ////////////////////////////////

        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            anim.SetBool("Jump", true);

            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVel;
        }

        if (Input.GetKeyUp(KeyCode.W) && anim.GetBool("Jump") == true)
        {
            grounded = false;
        }

        ////////////////////////// SLIDE ////////////////////////////////
        if (SlideEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.S) && grounded == true)
            {
                //MoveEnabled = false;
                anim.SetBool("Slide", true);
                GetComponent<BoxCollider2D>().offset = new Vector2(0.01091599f, -0.1300174f);
                GetComponent<BoxCollider2D>().size = new Vector2(1.055252f, 0.4266595f);
                controle = true;
            }

            if (controle == true)
                timer += Time.deltaTime;

            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || timer > 1f)
            {
                //MoveEnabled = true;
                anim.SetBool("Slide", false);
                GetComponent<BoxCollider2D>().offset = new Vector2(-0.005492329f, -0.02196747f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.5390164f, 1.126065f);
                timer = 0;
                controle = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            grounded = true;
            anim.SetBool("Jump", false);
        }

        if(collision.gameObject.tag == "Box")
        {
            timerRun = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            anim.SetBool("Die", true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Collider2D>().enabled = false;
            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Pneu")
        {
            timerRun = 0;
        }
    }
}
