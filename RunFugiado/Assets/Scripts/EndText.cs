using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour {
    public GameObject[] obj;
    public GameObject[] txt;
    public int random;
    public float timer;
    public Color col;

    public float vel;
	// Use this for initialization
	void Start () {
        col.a = 0;
        col.r = col.g = col.b = 255;

        random = Random.Range(0, txt.Length);

        txt[random].SetActive(true);
        txt[random].GetComponent<Image>().color = col;

        foreach (GameObject go in obj)
        {
            go.SetActive(false);
            go.GetComponent<Image>().color = col;
        }
	}
	
	// Update is called once per frame
	void Update () {
       // transform.Translate(0, vel * Time.deltaTime, 0);

        if (timer > 0.1f && col.a < 1)
        {
            col.a += 0.05f;
            timer = 0;
        }
        
        if(Input.anyKeyDown)
        {
            vel = 350;
        }

       /* if (GetComponent<RectTransform>().localPosition.y >= 350)
        {*/
            timer += Time.deltaTime;

            txt[random].SetActive(true);
            txt[random].GetComponent<Image>().color = col;

            foreach (GameObject go in obj)
                {
                    go.SetActive(true);
                    go.GetComponent<Image>().color = col;
                }

            vel = 0;
        //}
	}
}
