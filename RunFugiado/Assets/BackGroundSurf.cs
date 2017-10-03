using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSurf : MonoBehaviour {

    public List<Transform> bgPos = new List<Transform>();

    public float initPos;
    public float finishPos;
    public float speed;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        for (int x = 0; x < bgPos.Count; x++)
        {
            bgPos[x].Translate(Vector3.left * speed * Time.deltaTime);
            if (bgPos[x].position.x < finishPos)
            {
                bgPos[x].position = new Vector3(initPos, 0f, 0f);
            }
        }
	}
}
