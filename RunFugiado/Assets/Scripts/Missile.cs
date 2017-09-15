using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
    public float Vel;
    // Use this for initialization
    void Start () {
        Vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel * 3.5f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vel * Time.deltaTime, 0, 0);

        if(transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
