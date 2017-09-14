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

    public float timer;
    public float random;
    // Use this for initialization
    void Start () {
        boxPosX = 2f;
        boxPosY = -3.772897f;

        tirePosX = 2f;
        tirePosY = -3.99f;

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > 2.5f)
        {
            random = Random.Range(0, 2);

            if (random == 0)
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
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Bateu");
        }
    }
}
