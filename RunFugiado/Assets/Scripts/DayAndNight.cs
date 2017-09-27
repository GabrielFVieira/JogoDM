using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayAndNight : MonoBehaviour {
    public Sprite[] fases;
    public GameObject night;
    public float vel;

    public Color color;
    public float timer;

    public GameObject stars;
    public Color color2;

	// Use this for initialization
	void Start () {
        vel = 0.5f;
        GetComponent<SpriteRenderer>().sprite = fases[0];
        night.SetActive(false);
        stars.SetActive(false);
        color = night.GetComponent<Image>().color;
        color2 = stars.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
    }
	
	// Update is called once per frame
	void Update () {
        if (night.activeSelf == true)
        {
            timer += Time.deltaTime;

            if (transform.position.x >= GameObject.FindGameObjectWithTag("MainCamera").transform.position.x && color.a <= 0.6f)
            {
                if (timer > 0.5f)
                {
                    color.a += 0.01f;
                    color2.a += 0.03f;
                    timer = 0;
                }
            }

            if (transform.position.x < GameObject.FindGameObjectWithTag("MainCamera").transform.position.x && color.a >= 0.3)
            {
                if (timer > 0.5f)
                {
                    color.a -= 0.01f;
                    color2.a -= 0.03f;
                    timer = 0;
                }
            }
            stars.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color2;
            night.GetComponent<Image>().color = color;
        }

        transform.Translate(-vel * Time.deltaTime, 0, 0);

        if (GetComponent<SpriteRenderer>().sprite == fases[1])
        {
            night.SetActive(true);
            stars.SetActive(true);
        }

        else
        {
            night.SetActive(false);
            stars.SetActive(false);
        }

        if (transform.position.x < -20f)
        {
            transform.position = new Vector3(2 ,transform.position.y, transform.position.z);
            
            if (GetComponent<SpriteRenderer>().sprite == fases[0])
                GetComponent<SpriteRenderer>().sprite = fases[1];

            else
                GetComponent<SpriteRenderer>().sprite = fases[0];
        }

        if(Application.loadedLevelName == "Game")
        if (GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().gameTimer >= GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().MaxTime || GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Die") == true)
            vel = 0.1f;
	}
}
