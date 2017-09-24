using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {
    public Animator animo;
    public Parallax bg;

    public float timer;
    public bool controle;
	// Use this for initialization
	void Start () {
        animo = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(animo.GetBool("Col") == true)
        {
            transform.Translate(-bg.parallaxVel * Time.deltaTime, 0, 0);
        }

        if (animo.GetBool("Jump") == true || animo.GetBool("Slide") == true)
        {
            animo.SetBool("Col", false);
        }

        if (controle == true)
        {
            timer += Time.deltaTime;
            transform.Translate(-bg.parallaxVel * Time.deltaTime, 0, 0);
        }

        if(timer > 0.5f)
        {
            animo.SetBool("Fall", false);
            timer = 0;
            controle = false;
        }
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(GetComponent<Jump>().controle == false && GetComponent<Jump>().grounded == true)
        if(col.gameObject.tag == "Box")
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
