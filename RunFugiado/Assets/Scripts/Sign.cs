using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public float timer;
    public bool controle;

    public Sprite[] breaks;

    public SpriteRenderer front;

    public GameObject back;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -18.5f)
            GetComponent<AudioSource>().volume = 0.2f;

        if (controle == true)
            timer += Time.deltaTime;

        if(timer > 0.2f)
        {
            GetComponent<Animator>().enabled = false;
            front.GetComponent<Animator>().enabled = false;

            GetComponent<SpriteRenderer>().sprite = breaks[1];
            front.GetComponent<SpriteRenderer>().sprite = breaks[0];
        }

        if (GetComponent<Animator>().enabled == true)
           back.GetComponent<Animator>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            controle = true;
            GetComponent<Animator>().enabled = true;
            front.GetComponent<Animator>().enabled = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
