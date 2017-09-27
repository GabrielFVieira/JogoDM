using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pneu : MonoBehaviour {
    public float vel;
    public bool controle;

    public ObstacleManager move;
	// Use this for initialization
	void Start () {
        vel = 10;
        controle = true;
	}
	
	// Update is called once per frame
	void Update () {
            if (controle == true && Time.timeScale != 0)
                transform.Rotate(0, 0, vel);
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            controle = false;
        }
    }
}
