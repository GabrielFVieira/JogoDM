using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextsManager : MonoBehaviour {
    public float timer;
    public int random;
    public int last;
    //public GameObject txtBG;
    public GameObject[] txts;

    public float scaleX;
	// Use this for initialization
	void Start () {
        scaleX = 0;

        //txtBG.SetActive(false);

        foreach (GameObject go in txts)
            go.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > 10 && txts[random].activeSelf == false)
        {
            random = Random.Range(1, txts.Length);
            if (random != last)
            {
                //txtBG.SetActive(true);
                txts[random].SetActive(true);
                last = random;
            }
        }

        if (txts[random].activeSelf == true && timer < 20)
        {
            if (scaleX < 1)
                scaleX += 0.03f;

            else
                scaleX = 1;

            //txtBG.transform.localScale = new Vector3(scaleX, 1, 0);
            txts[random].transform.localScale = new Vector3(scaleX, 1, 0);
        }

        if (timer > 20 && txts[random].activeSelf == true)
        {
            //txtBG.transform.localScale = new Vector3(scaleX, 1, 0);
            txts[random].transform.localScale = new Vector3(scaleX, 1, 0);

            if (scaleX > 0)
                scaleX -= 0.03f;

            else
                scaleX = 0;

            if (scaleX == 0)
            {
                //txtBG.SetActive(false);
                txts[random].SetActive(false);
                timer = 0;
            }
        }
    }
}
