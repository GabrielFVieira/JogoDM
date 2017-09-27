using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelect : MonoBehaviour {
    public string Up;
    public string Down;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Up = "UpArrow";
        Down = "DownArrow";
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Menu")
            Destroy(gameObject);
	}

    public void W()
    {
        Up = "W";
        Down = "S";
    }

    public void S()
    {
        Down = "S";
        Up = "W";
    }

    public void UpArrow()
    {
        Up = "UpArrow";
        Down = "DownArrow";
    }

    public void DownArrow()
    {
        Down = "DownArrow";
        Up = "UpArrow";
    }
}
