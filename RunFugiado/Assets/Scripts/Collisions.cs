using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {
    public Animator animo;
	// Use this for initialization
	void Start () {
        GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Box")
        {
            
        }

        if (col.gameObject.tag == "ExplosionBox")
        {
            
        }

        if (col.gameObject.tag == "Sign")
        {
            
        }

        if (col.gameObject.tag == "Missile")
        {
            
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pneu")
        {
            
        }
    }
}
