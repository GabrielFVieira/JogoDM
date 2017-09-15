using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Animator>().GetBool("Explode") == true)
            {
                timer += Time.deltaTime;
            }

        if(timer > 0.4f)
        {
            Destroy(gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("Explode", true);
            transform.localScale = new Vector3(1, 1, 1);
            Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            GetComponent<Animator>().SetBool("Explode", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
