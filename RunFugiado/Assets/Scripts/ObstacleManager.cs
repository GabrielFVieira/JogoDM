using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    public float Vel;

    public bool move;

    public float timer;
	// Use this for initialization
	void Start () {
        move = true;

        if (gameObject.tag == "Pneu")
        {
            Vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel * 1.5f;
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
    }
}
