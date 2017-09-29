using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntantiateBg : MonoBehaviour {
    public GameObject posX;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(posX.transform.position.x + posX.GetComponent<SpriteRenderer>().bounds.size.x, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
