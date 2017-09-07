using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    [Range(1, 10)]
    public float parallaxVel;

    public GameObject cam;
	// Use this for initialization
	void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-parallaxVel * Time.deltaTime, 0, 0);

        if(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2) < cam.transform.position.x - (GetComponent<SpriteRenderer>().bounds.size.x / 2))
        {
            transform.position = new Vector3(cam.transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x) - 0.15f, -0.04f, 0);
        }
	}
}
