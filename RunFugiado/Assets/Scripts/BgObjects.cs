using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgObjects : MonoBehaviour {
    public GameObject[] obj;
    public float random;
    public float timer;
    public float randomMax;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            random = Random.Range(0, randomMax);

            if (random <= obj.Length)
            {
                GameObject bgObj = Instantiate(obj[Mathf.FloorToInt(random)]) as GameObject;
                timer = 0;
            }

            else
                timer = 0;
        }
	}
}
