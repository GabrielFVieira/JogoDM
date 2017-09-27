using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    public GameObject Cloud1;
    public GameObject Cloud2;
    public GameObject Cloud3;

    public float random;
    public float randomDelay;
    public float delay;
    public float randomPos;
    public float posY;

    public float timer;

    public LevelManager manager;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        randomDelay = Random.Range(0, 5);

        if (randomDelay == 0)
            delay = 2f;

        if (randomDelay == 1)
            delay = 2.8f;

        if (randomDelay == 2)
            delay = 3f;

        if (randomDelay == 3)
            delay = 3.6f;

        if (randomDelay == 4)
            delay = 4f;

        if (timer > delay && manager.gameTimer <= manager.MaxTime)
        {
            random = Random.Range(0, 3);
            randomPos = Random.Range(1.97f, 4.48f);
            if (random == 0)
            {
                GameObject cloud1 = Instantiate(Cloud1) as GameObject;
                cloud1.transform.position = new Vector3(2f, randomPos, 0);
                timer = 0;
            }

            if (random == 1)
            {
                GameObject cloud2 = Instantiate(Cloud2) as GameObject;
                cloud2.transform.position = new Vector3(2f, randomPos, 0);
                timer = 0;
            }

            if (random == 2)
            {
                GameObject cloud3 = Instantiate(Cloud3) as GameObject;
                cloud3.transform.position = new Vector3(2f, randomPos, 0);
                timer = 0;
            }
        }
    }
}
