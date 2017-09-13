using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {
    public GameObject box;
    public float boxPosX;
    public float boxPosY;

    public float TimerBox;
	// Use this for initialization
	void Start () {
        boxPosX = 2f;
        boxPosY = -3.33f;
	}
	
	// Update is called once per frame
	void Update () {
        TimerBox += Time.deltaTime;

        if(TimerBox > 1.5f)
        {
            GameObject boxObstacle = Instantiate(box) as GameObject;
            boxObstacle.transform.position = new Vector3(boxPosX , boxPosY, 0);
            TimerBox = 0;
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
