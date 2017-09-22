using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    public GameObject player;
    public Parallax parallax;
    public float vel;
	// Use this for initialization
	void Start () {
        vel = parallax.parallaxVel;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetComponent<Animator>().GetBool("Die") == true)
        {
            //GetComponent<SpriteRenderer>().sortingOrder = 10;
            transform.Translate(vel * Time.deltaTime, 0, 0);
        }
	}
}
