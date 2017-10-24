using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {
    public Animator animo;
    public Parallax bg;

    public float timer;
    public bool controle;

	public bool controle2;
	public bool colSign;

    public bool controle3;
    // Use this for initialization
    void Start () {
        animo = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(animo.GetBool("Col") == true)
        {
			bg.parallaxVel = 0;
			controle2 = true;
            //transform.Translate(-bg.parallaxVel * Time.deltaTime, 0, 0);
        }

        if (animo.GetBool("Fall") == true)
        {
            bg.parallaxVel = 0;
            controle3 = true;
            //transform.Translate(-bg.parallaxVel * Time.deltaTime, 0, 0);
        }

        if (animo.GetBool("Fall") == false && controle3 == true)
        {
            bg.parallaxVel = 4;
            controle3 = false;
            //transform.Translate(-bg.parallaxVel * Time.deltaTime, 0, 0);
        }

        if (animo.GetBool("Col") == false && transform.position.y > -2.5f && controle2 == true && colSign == false)
		{
			bg.parallaxVel = 4;
			controle2 = false;
			//transform.Translate(-bg.parallaxVel * Time.deltaTime, 0, 0);
		}

		if(animo.GetBool("Col") == false && colSign == true && controle2 == true)
		{
			bg.parallaxVel = 4;
			colSign = false;
			controle2 = false;
			//transform.Translate(-bg.parallaxVel * Time.deltaTime, 0, 0);
		}

        if (animo.GetBool("Jump") == true || animo.GetBool("Slide") == true)
        {
            animo.SetBool("Col", false);
        }

        if (controle == true)
        {
            timer += Time.deltaTime;
            //transform.Translate(-bg.parallaxVel * Time.deltaTime, 0, 0);
        }

        if(timer > 0.5f)
        {
			bg.parallaxVel -= 1f;
            animo.SetBool("Fall", false);
            timer = 0;
            controle = false;
        }
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (GetComponent<Jump>().controle == false && GetComponent<Jump>().grounded == true)
        if(col.gameObject.tag == "Box" && transform.position.y < -2.45f)
        {
            animo.SetBool("Col", true);
        }

        if (col.gameObject.tag == "ExplosionBox")
        {
            animo.SetBool("Col", true);
        }

        if (col.gameObject.tag == "Missile")
        {
            animo.SetBool("Col", true);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pneu" && controle == false && col.GetComponentInChildren<SpriteRenderer>().sprite != col.GetComponent<ObstacleManager>().fallTire)
        {
            animo.SetBool("Fall", true);
            controle = true;
        }

        if (col.gameObject.tag == "Sign" && animo.GetBool("Jump") == false)
        {
            animo.SetBool("Col", true);
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sign" && animo.GetBool("Jump") == false)
        {
			colSign = true;
            animo.SetBool("Col", true);
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sign")
        {
            animo.SetBool("Col", false);
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Box")
        {
            animo.SetBool("Col", false);
        }

        if (col.gameObject.tag == "ExplosionBox")
        {
            animo.SetBool("Col", false);
        }

        if (col.gameObject.tag == "Missile")
        {
            animo.SetBool("Col", false);
        }
    }
}
