using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Back : MonoBehaviour {
    public GameObject sons;
	// Use this for initialization
	void Start () {
        sons.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Voltar()
    {
        SceneManager.LoadScene("Options");
    }

    public void Sons()
    {
        sons.SetActive(!sons.activeSelf);
    }
}
