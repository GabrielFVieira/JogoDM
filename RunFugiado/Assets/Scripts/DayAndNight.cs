using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour {
    public Sprite[] fases;

    public float vel;
	// Use this for initialization
	void Start () {
        vel = 0.5f;
        GetComponent<SpriteRenderer>().sprite = fases[0];
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-vel * Time.deltaTime, 0, 0);

        if(transform.position.x < -20f)
        {
            transform.position = new Vector3(2 ,transform.position.y, transform.position.z);
            
            if (GetComponent<SpriteRenderer>().sprite == fases[0])
                GetComponent<SpriteRenderer>().sprite = fases[1];

            else
                GetComponent<SpriteRenderer>().sprite = fases[0];
        }
	}
}
