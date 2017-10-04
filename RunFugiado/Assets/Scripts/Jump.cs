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
    public float timerCD;
    public bool controle;
    public bool controleCD;

    public float timerRun;

    public Animator anim;

    public float dieTimer;
    public Sprite dead;
    public Sprite tank;

    public float vel;

    public bool controlJump;

    public AudioSource jump;
    public AudioSource slide;

	// Use this for initialization
	void Start () {
        moveVel = 1f;

        controlJump = true;

        vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel;

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool jumpDown = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        bool jumpUp = Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W);
        bool slideDown = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
        bool slideUp = Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S);

        if (anim.GetBool("Die") == true)
        {
            if (transform.position.y > -3.33f && anim.GetBool("Slide") == false)
                transform.Translate(0, -GetComponent<BetterJump>().fallVel * Time.deltaTime, 0);

            if (transform.position.y <= -3.33f)
            {
                transform.position = new Vector3(transform.position.x, -3.33f, transform.position.z);
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
            dieTimer += Time.deltaTime;
            GetComponent<SpriteRenderer>().sortingOrder = GameObject.FindGameObjectWithTag("Tank").GetComponent<SpriteRenderer>().sortingOrder - 1;
           
        }

        if(dieTimer > 0.5f)
        {
            anim.enabled = false;
            GetComponent<SpriteRenderer>().sprite = dead;
        }

        if (anim.GetBool("Die") == false)
        {
            if (transform.position.x < -6.84f)
            {
                timerRun += Time.deltaTime;
            }

            if (timerRun > 15)
            {
                move = true;
            }

            if (transform.position.x >= -6.84f)
            {
                move = false;
                timerRun = 0;
            }
        }
        if (move == true && anim.GetBool("Die") == false)// && anim.GetBool("Slide") == false && anim.GetBool("Jump") == false)
        {
            transform.Translate(moveVel * Time.deltaTime, 0, 0);
        }

        if(GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().gameTimer >= GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().MaxTime - 5 && GameObject.FindGameObjectWithTag("Tank").transform.position.x >= -21.5f && anim.GetBool("Die") == false)
            GameObject.FindGameObjectWithTag("Tank").transform.Translate(-vel * Time.deltaTime, 0, 0);

        if (GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().gameTimer >= GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().MaxTime && anim.GetBool("Die") == false)
            {
                if (anim.GetBool("Col") == false)
                    transform.Translate(vel * 0.8f * Time.deltaTime, 0, 0);
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
        if (jumpDown && grounded == true && anim.GetBool("Fall") == false && Time.timeScale > 0 && controlJump == true)
            {
                anim.SetBool("Jump", true);
                jump.Play();
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVel;
                controlJump = false;
            }

            if (jumpUp && anim.GetBool("Jump") == true)
            {
                grounded = false;
               
            }
            
            if(anim.GetBool("Jump") == false)
                controlJump = true;

        ////////////////////////// SLIDE ////////////////////////////////
        if (SlideEnabled == true && Time.timeScale > 0)
            {
                if (slideDown && grounded == true && anim.GetBool("Fall") == false && timerCD == 0)
                {
                    //MoveEnabled = false;
                    slide.Play();
                    anim.SetBool("Slide", true);
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
                    GetComponent<BoxCollider2D>().offset = new Vector2(0.01091599f, -0.1300174f);
                    GetComponent<BoxCollider2D>().size = new Vector2(1.055252f, 0.4266595f);
                    controle = true;
                    controleCD = true;
                }

                if (controle == true)
                {
                    timer += Time.deltaTime;
                }

                if (controleCD == true)
                {
                    timerCD += Time.deltaTime;
                }

                if (timerCD > 0.5f)
                {
                    timerCD = 0;
                    controleCD = false;
                }

                if (slideUp ||jumpDown || timer > 1f && anim.GetBool("Fall") == false)
                {
                    //MoveEnabled = true;
                    slide.Stop();
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
            move = false;
        }
    }
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            anim.SetBool("Die", true);
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Collider2D>().enabled = false;
            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Pneu")
        {
            timerRun = 0;
            move = false;
        }        
    }
}
