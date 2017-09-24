using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    [Range(1, 10)]
    public float parallaxVel;

    public float minX;
    public float startX ;

    public GameObject cam;

    public LevelManager manager;
	// Use this for initialization
	void Start () {
        minX = -27.36997f;
        startX = 10.67622f;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Die") == false)
        {
            transform.Translate(-parallaxVel * Time.deltaTime, 0, 0);
            /*
            if (transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2) < cam.transform.position.x - (GetComponent<SpriteRenderer>().bounds.size.x / 2))
            {
                transform.position = new Vector3(cam.transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x) - parallaxVel * Time.deltaTime, transform.position.y, transform.position.z);
            }*/
            
            if (transform.position.x < minX)
                transform.position = new Vector3(startX, transform.position.y);
            
            if(manager.gameTimer >=  20 && manager.gameTimer < 40)
                parallaxVel = 5.8f;

            if (manager.gameTimer >= 40 && manager.gameTimer < 60)
                parallaxVel = 6.6f;

            if (manager.gameTimer >= 60 && manager.gameTimer < 80)
                parallaxVel = 7.4f;

            if (manager.gameTimer >= 80 && manager.gameTimer < 100)
                parallaxVel = 8.2f;

            if (manager.gameTimer >= 100 && manager.gameTimer < 120)
                parallaxVel = 9f;

            if (manager.gameTimer >= 120)
                parallaxVel = 10f;
        }
        else
            parallaxVel = 0;
	}
}
