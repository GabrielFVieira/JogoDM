using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    public GameObject player;
    public Parallax parallax;
    public float vel;

	public float timer;
	public bool controle;

    public bool controle2;
    public float vel2;
	// Use this for initialization
	void Start () {
        vel = parallax.parallaxVel * 0.8f;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -19)
            GetComponent<AudioSource>().volume = 0.1f;

        if (GameObject.Find ("Bg").GetComponent<Parallax> ().parallaxVel > 0 && controle == false && controle2 == false)
			vel = parallax.parallaxVel * 0.8f;

		if (GameObject.Find ("Bg").GetComponent<Parallax> ().parallaxVel > 0 && transform.position.x > -21.5f && player.GetComponent<Animator>().enabled == true) {
			timer += Time.deltaTime;
			if (timer > 5) {
				controle = true;
				transform.Translate(-vel * Time.deltaTime * 0.6f, 0, 0);
			}
		}

		if (controle == true) 
		{
			vel -= 0.0001f;
		}

        if (vel2 < 0)
            vel2 = 0;

        if (controle2 == true && GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel > 0)
        {
            vel2 -= 0.1f;
            transform.Translate(vel2 * Time.deltaTime * 0.6f, 0, 0);
        }

        if (transform.position.x <= -21.5f)
        {
            timer = 0;
            controle = false;
            controle2 = false;
            vel2 = vel;
        }

		if (GameObject.Find ("Bg").GetComponent<Parallax> ().parallaxVel == 0 && player.GetComponent<Animator> ().GetBool ("Die") == false) {
			timer = 0;
            controle2 = true;
            vel2 = vel;
			transform.Translate (vel * Time.deltaTime, 0, 0);
		}

		if(transform.position.x > -21.5f && GameObject.Find("Manager").GetComponent<LevelManager>().gameTimer < 3 && player.GetComponent<Animator>().enabled == true)
			transform.Translate(-vel * Time.deltaTime * 0.6f, 0, 0);

		if(player.GetComponent<Animator>().GetBool("Die") == true)
        {
            //GetComponent<SpriteRenderer>().sortingOrder = 10;
            transform.Translate(vel * Time.deltaTime, 0, 0);
        }
	}
}
