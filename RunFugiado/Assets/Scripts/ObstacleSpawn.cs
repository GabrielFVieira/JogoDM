using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {
    public GameObject box;
    public float boxPosX;
    public float boxPosY;
    //public float TimerBox;

    public GameObject tire;
    public float tirePosX;
    public float tirePosY;
    //public float TimerTire;

    public GameObject sign;
    public float signPosX;
    public float signPosY;

    public GameObject explode;
    public float explodePosX;
    public float explodePosY;

    public GameObject missile;
    public float missilePosX;
    //public float missilePosY;

    public float timer;
    public float maxTimer;
    public float random;

    public float randomMissilePosX;
    public GameObject[] alerts;


    public float difficultTimer;
    public float gameTimer;
    // Use this for initialization
    void Start () {
        maxTimer = 2.5f;

        boxPosX = 2f;
        boxPosY = -3.772897f;

        tirePosX = 2f;
        tirePosY = -3.763f;

        signPosX = 2.8f;
        signPosY = -2.88f;

        explodePosX = 2f;
        explodePosY = -3.8f;

        missilePosX = 10f;

    }
	
	// Update is called once per frame
	void Update () {
        gameTimer += Time.deltaTime;
        difficultTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if(difficultTimer > 30f)
        {
            maxTimer -= 0.1f;
            difficultTimer = 0;
        }

        maxTimer = Mathf.Round(Random.Range(1.3f, 2.6f) * 10) / 10;

        if(timer > maxTimer)
        {
            random = Random.Range(0, 5);

            if(random == 2)
            {
                if (gameTimer > 30)
                {
                    randomMissilePosX = Random.Range(0, 2);

                    if (randomMissilePosX == 0)
                    { 
                        GameObject missileObstacle = Instantiate(missile) as GameObject;
                        missileObstacle.transform.position = new Vector3(missilePosX, -2.77f, 0);
                        alerts[Mathf.RoundToInt(randomMissilePosX)].SetActive(true);
                        timer = 0;
                    }

                    else
                    {
                        GameObject missileObstacle = Instantiate(missile) as GameObject;
                        missileObstacle.transform.position = new Vector3(missilePosX, -3.63f, 0);
                        alerts[Mathf.RoundToInt(randomMissilePosX)].SetActive(true);
                        timer = 0;
                    }
                }

                else
                {
                    GameObject boxObstacle = Instantiate(box) as GameObject;
                    boxObstacle.transform.position = new Vector3(boxPosX, boxPosY, 0);
                    timer = 0;
                }
            }

            else if (random == 0)
            {
                GameObject boxObstacle = Instantiate(box) as GameObject;
                boxObstacle.transform.position = new Vector3(boxPosX, boxPosY, 0);
                timer = 0;
            }

            else if (random == 1)
            {
                GameObject tireObstacle = Instantiate(tire) as GameObject;
                tireObstacle.transform.position = new Vector3(tirePosX, tirePosY, 0);
                timer = 0;
            }

            else if (random == 3)
            {
                GameObject signObstacle = Instantiate(sign) as GameObject;
                signObstacle.transform.position = new Vector3(signPosX, signPosY, 0);
                timer = 0;
            }

            else if (random == 4)
            {
                GameObject explodeObstacle = Instantiate(explode) as GameObject;
                explodeObstacle.transform.position = new Vector3(explodePosX, explodePosY, 0);
                timer = 0;
            }


        }

    }
}
