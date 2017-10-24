using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            if (transform.position.x < -18.5f)
                GetComponent<AudioSource>().volume = 0.6f;

            GetComponent<AudioSource>().Play();
        }
    }
}
