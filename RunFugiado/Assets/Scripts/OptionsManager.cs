using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour {
    public Slider vol;
    public Sprite[] volume;
    public GameObject Sound;
	// Use this for initialization
	void Start () {
        vol.value = AudioListener.volume;
        Time.timeScale = 1;
    }

    public void FixedUpdate()
    {
        AudioListener.volume = vol.value;
    }

    // Update is called once per frame
    void Update () {
        if(AudioListener.volume >= 0.7f)
        {
            Sound.GetComponent<Image>().sprite = volume[0];
        }

        if (AudioListener.volume >= 0.3f && AudioListener.volume < 0.7f)
        {
            Sound.GetComponent<Image>().sprite = volume[1];
        }

        if(AudioListener.volume > 0 && AudioListener.volume < 0.3f)
        {
            Sound.GetComponent<Image>().sprite = volume[2];
        }

        if (AudioListener.volume == 0)
        {
            Sound.GetComponent<Image>().sprite = volume[3];
        }

    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
