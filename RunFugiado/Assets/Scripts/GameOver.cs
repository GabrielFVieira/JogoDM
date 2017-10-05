using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    { 
        SceneManager.LoadScene("Game");
    }
}
