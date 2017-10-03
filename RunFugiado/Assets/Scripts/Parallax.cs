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
<<<<<<< HEAD
	// Use this for initialization
	void Start () {
        /*minX = -27.36997f;
        startX = 10.67622f;*/
=======
    /*
    private double verticalSize;
    private double horizontalSize;
    public float cameraOffset;*/

    // Use this for initialization
    void Start () {
        minX = -27.36997f;
        startX = 10.67622f;

        /*
        verticalSize = Camera.main.orthographicSize * 2.0;
        horizontalSize = verticalSize * Screen.width / Screen.height;        

>>>>>>> f52415e431c73352e1e6ad5deb11f0701dba4b58
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();
        cameraOffset = cam.transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x);*/
    }
	
	// Update is called once per frame
	void Update () {


        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Die") == false)
        {
            // METODO DAYVID 
            if (transform.position.x < Mathf.Round(minX))
            {
                transform.position = new Vector3(Mathf.Round(startX), 0, 0);
            }

            transform.Translate(new Vector3(-parallaxVel, 0, 0) * Time.deltaTime);

            /*   transform.Translate(-parallaxVel * Time.deltaTime, 0, 0);

               if (transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2) < cam.transform.position.x - (horizontalSize / 2))
               {                
                   transform.position = new Vector3(cameraOffset, transform.position.y, transform.position.z);
                   Debug.Log(transform.position.x);
               }   */


            /*
            if (transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2) < cam.transform.position.x - (GetComponent<SpriteRenderer>().bounds.size.x / 2))
            {
                transform.position = new Vector3(cam.transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x), transform.position.y, transform.position.z);
            }*/
<<<<<<< HEAD

            if (transform.localPosition.x < minX)
            {
                if (GetComponent<SpriteRenderer>().sprite == bg[0])
                    GetComponent<SpriteRenderer>().sprite = bg[2];

                else if (GetComponent<SpriteRenderer>().sprite == bg[1])
                    GetComponent<SpriteRenderer>().sprite = bg[0];

                else if (GetComponent<SpriteRenderer>().sprite == bg[2])
                    GetComponent<SpriteRenderer>().sprite = bg[1];

                transform.localPosition = new Vector3(startX, 4.33f);
            }
            
            if(manager.gameTimer >=  20 && manager.gameTimer < 40)
=======
            /*
            if (transform.position.x < minX)
                transform.position = new Vector3(startX, transform.position.y);
            */
            if (manager.gameTimer >= 20 && manager.gameTimer < 40)
>>>>>>> f52415e431c73352e1e6ad5deb11f0701dba4b58
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
