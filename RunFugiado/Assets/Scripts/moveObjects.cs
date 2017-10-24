using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObjects : MonoBehaviour {
    public float Vel;
    // Use this for initialization
    void Start()
    {
            Vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel;
    }

    // Update is called once per frame
    void Update () {
		Vel = GameObject.Find("Bg").GetComponent<Parallax>().parallaxVel;

        if (transform.position.x < -25)
            Destroy(gameObject);

        if (GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().gameTimer <= GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>().MaxTime)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Die") == false)
            {
                transform.Translate(-Vel * Time.deltaTime, 0, 0);
            }
        }
    }
}
