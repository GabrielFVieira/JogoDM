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

    public float newPosition;

    public Vector3 startPosition;
    void Start () {
        startPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {


		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ().GetBool ("Die") == false) {/*
			newPosition = Mathf.Repeat (Time.time * parallaxVel * 0.71f, minX);
			transform.localPosition = startPosition + Vector3.left * newPosition;
			*/
			if (transform.localPosition.x < -18.3f)
			{
				transform.localPosition = new Vector3(transform.localPosition.x + 22.679995f ,startPosition.y, startPosition.z);
			}

			transform.Translate (-parallaxVel * Time.deltaTime, 0, 0);

			Mathf.Clamp (transform.localPosition.x, -18.3f, 4.3f);
			// METODO DAYVID 
			/*if (transform.position.x < Mathf.Round(minX))
            {
                transform.position = new Vector3(Mathf.Round(startX), 0, 0);
            }*/
			/*
            transform.Translate(new Vector3(-parallaxVel, 0, 0) * Time.deltaTime);

            if (transform.localPosition.x <= minX)
            {
                Debug.Log(transform.localPosition.x);
                transform.localPosition = new Vector3(startX + (-parallaxVel * Time.deltaTime), 1.27f);
            }*/
			if (Time.timeScale > 0) {
				if (parallaxVel > 0 && parallaxVel < 5)
					parallaxVel += 0.05f;

				if (parallaxVel >= 5 && parallaxVel < 8 && manager.gameTimer < 20)
					parallaxVel += 0.0005f;

				if (parallaxVel >= 5 && parallaxVel < 8 && manager.gameTimer >= 20 && manager.gameTimer < 40)
					parallaxVel += 0.0008f;

				if (parallaxVel >= 5 && parallaxVel < 8 && manager.gameTimer >= 40 && manager.gameTimer < 80)
					parallaxVel += 0.0011f;

				if (parallaxVel >= 5 && parallaxVel < 8 && manager.gameTimer >= 80 && manager.gameTimer < 120)
					parallaxVel += 0.0015f;

				if (manager.gameTimer >= 120)
					parallaxVel = 0;
			}
		}
       
    }
}
