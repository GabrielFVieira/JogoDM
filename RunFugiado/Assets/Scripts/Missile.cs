using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missile : MonoBehaviour {
    public float Vel;

    public float timer;
    public AudioSource explosion;
    // Use this for initialization
    void Start () {
        Vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel * 2f;
        explosion = GameObject.Find("Explosion").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Animator>().GetBool("Explode") == false)
        transform.Translate(-Vel * Time.deltaTime, 0, 0);

        if (GetComponent<Animator>().GetBool("Explode") == true)
        {
            timer += Time.deltaTime;
        }

        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }

        if (timer > 0.4f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            explosion.Play();
            transform.position = col.transform.position;
            GetComponent<Animator>().SetBool("Explode", true);
            transform.localScale = new Vector3(1, 1, 1);
            col.gameObject.GetComponent<Animator>().SetBool("Die", true);
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //Destroy(gameObject);
        }
    }
}
