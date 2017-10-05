using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour {
    public float timer;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "PreMenu")
        {
            timer += Time.deltaTime;

            if(timer > 1.5f)
            {
                SceneManager.LoadScene("Menu");
                timer = 0;
            }
        }

            if (GetComponent<AudioSource>().isPlaying == false && SceneManager.GetActiveScene().name == "Menu")
        {
            GetComponent<AudioSource>().Play();
        }

        if(SceneManager.GetActiveScene().name == "InstructionsScene")
            GetComponent<AudioSource>().Stop();
    }
}
