using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public bool controle;
    public float timer;
    public Sprite broke;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (controle == true)
            timer += Time.deltaTime;

        if(timer > 0.23f)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = broke;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            if (transform.position.x < -18.5f)
                GetComponent<AudioSource>().volume = 0.15f;

            controle = true;
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().enabled = true;
        }
    }
}
