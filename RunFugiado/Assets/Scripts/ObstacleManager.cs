using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    public float Vel;
	// Use this for initialization
	void Start () {
        Vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vel * Time.deltaTime, 0, 0);
    }
}
