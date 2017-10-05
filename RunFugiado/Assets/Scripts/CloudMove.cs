using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {
    public DayAndNight day;
    public float vel;
	// Use this for initialization
	void Start () {
        day = GameObject.Find("SolELua").GetComponent<DayAndNight>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale > 0 && GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Die") == false)
        {
            vel = day.vel * 0.05f;
            transform.Translate(-vel, 0, 0);
        }

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Die") == true && Time.timeScale > 0)
        {
            vel = day.vel * 0.01f;
            transform.Translate(-vel, 0, 0);
        }

        if (transform.position.x < -21)
            Destroy(gameObject);
    }
}
