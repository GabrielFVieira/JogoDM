using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour {
    public float timer;
    public bool controle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
        {
            controle = true;
        }

        if (controle == true)
            timer += Time.deltaTime;

        if (timer > 0.15f)
            StartGame();
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
