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

    public Parallax[] bg;

    public float vol;
    // Use this for initialization
    void Start () {
        vol = AudioListener.volume;

        pauseMenu.SetActive(false);
        Time.timeScale = 1;
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
        /*
        if(gameTimer > 20 && gameTimer < 20.5f || gameTimer > 35 && gameTimer < 35.5f || gameTimer > 50 && gameTimer < 50.5f)
        {
            foreach(Parallax go in bg)
            {
                go.parallaxVel += 0.2f;
            }
        }
        */
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

        Cursor.visible = pauseMenu.activeSelf;

        if (pauseMenu.activeSelf == true)
        {
            Time.timeScale = 0;
            AudioListener.volume = 0;
        }

        else
        {
            Time.timeScale = 1;
            AudioListener.volume = vol;
        }
        if(gameTimer >= MaxTime)
        {
            foreach (Parallax go in bg)
            {
                go.parallaxVel = 0;
            }

            if(GameObject.FindGameObjectWithTag("Player").transform.position.x > 0)
                SceneManager.LoadScene("EndGame");
        }

        if(GameObject.FindGameObjectWithTag("Tank").transform.position.x > 5.49f)
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
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
