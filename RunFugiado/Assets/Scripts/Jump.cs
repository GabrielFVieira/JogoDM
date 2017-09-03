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

    public Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        ////////////////////////// Move ////////////////////////////////
        if (MoveEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                move = true;
                moveVel = -2.5f;
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                move = true;
                moveVel = 2.5f;
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

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            anim.SetBool("Jump", true);

            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVel;
        }

        if (Input.GetButtonUp("Jump") && anim.GetBool("Jump") == true)
        {
            grounded = false;
        }

        ////////////////////////// SLIDE ////////////////////////////////
        if (SlideEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && grounded == true)
            {
                anim.SetBool("Slide", true);
                GetComponent<BoxCollider2D>().offset = new Vector2(0.01091601f, -0.03294219f);
                GetComponent<BoxCollider2D>().size = new Vector2(1.055252f, 0.6208104f);
            }

            if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetButtonDown("Jump"))
            {
                anim.SetBool("Slide", false);
                GetComponent<BoxCollider2D>().offset = new Vector2(-0.005492329f, -0.02196747f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.5390164f, 1.126065f);
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
    }
}
