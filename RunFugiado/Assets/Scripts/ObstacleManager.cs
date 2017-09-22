using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    public float Vel;

    public bool move;

    public Sprite fallTire;

    public float timer;
	// Use this for initialization
	void Start () {
        move = true;

        if (gameObject.tag == "Pneu")
        {
            Vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel * 1.4f;
        }

        else
            Vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel;
	}
	
	// Update is called once per frame
	void Update () {
        if(move == true && GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Die") == false)
            {
                transform.Translate(-Vel * Time.deltaTime, 0, 0);
            }
        }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Tank")
        {
            timer += Time.deltaTime;

            GetComponent<Collider2D>().isTrigger = true; 

            //GetComponent<Animator>().SetBool("Destroy", true);
            if(gameObject.tag == "Pneu")
            {
                GetComponentInChildren<Pneu>().enabled = false;

                if (transform.position.x < -16f)
                    move = false;
            }
            
            else if (transform.position.x < -15.3f)
                move = false;
            
            if(timer > 1f)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "Pneu")
        {
            transform.position = new Vector3(transform.position.x, -4.087f, transform.position.z);
            GetComponentInChildren<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponentInChildren<SpriteRenderer>().sprite = fallTire;
            //transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = false;

            transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
            GetComponentInChildren<Pneu>().enabled = false;

            Vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel;
        }
    }
}
