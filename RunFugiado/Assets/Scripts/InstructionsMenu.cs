using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
        {
            StartGame();
        }
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
