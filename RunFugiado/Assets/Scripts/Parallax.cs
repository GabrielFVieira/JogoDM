using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    [Range(0, 10)]
    public float parallaxVel;

    public float minX;
    public float startX ;

    public GameObject cam;

    public Sprite[] bg;

    public LevelManager manager;

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {


        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Die") == false)
        {
            // METODO DAYVID 
            /*if (transform.position.x < Mathf.Round(minX))
            {
                transform.position = new Vector3(Mathf.Round(startX), 0, 0);
            }*/

            transform.Translate(new Vector3(-parallaxVel, 0, 0) * Time.deltaTime);

            if (transform.localPosition.x < minX)
            {/*
                if (GetComponent<SpriteRenderer>().sprite == bg[0])
                    GetComponent<SpriteRenderer>().sprite = bg[2];

                else if (GetComponent<SpriteRenderer>().sprite == bg[1])
                    GetComponent<SpriteRenderer>().sprite = bg[0];

                else if (GetComponent<SpriteRenderer>().sprite == bg[2])
                    GetComponent<SpriteRenderer>().sprite = bg[1];
                */
                transform.localPosition = new Vector3(startX, 1.27f);
            }
               
                if (manager.gameTimer >= 20 && manager.gameTimer < 40)
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
                parallaxVel = 0;
        }
        else
            parallaxVel = 0;

       
    }
}
