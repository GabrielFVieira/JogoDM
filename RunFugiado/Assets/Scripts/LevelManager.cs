using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public GameObject pauseMenu;
    public float gameTimer;
    public float distance;
    public float distanceInt;

    public float MaxTime = 60;

    public Text text;
    // Use this for initialization
    void Start () {
        pauseMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("Die") == false)
        {
            gameTimer += Time.deltaTime;
            distance += 2 * Time.deltaTime;
            distanceInt = Mathf.RoundToInt(distance);
        }
        text.text = "Distância percorrida: " + distanceInt + " metros";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

        Cursor.visible = pauseMenu.activeSelf;

        if (pauseMenu.activeSelf == true)
        {
            Time.timeScale = 0;
        }

        else
            Time.timeScale = 1;

        if(gameTimer >= MaxTime)
        {
            SceneManager.LoadScene("EndGame");
        }

        if(GameObject.FindGameObjectWithTag("Tank").transform.position.x > 3.37f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
