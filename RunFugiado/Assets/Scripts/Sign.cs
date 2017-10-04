using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public Sprite[] breaks;

    public SpriteRenderer front;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            GetComponent<SpriteRenderer>().sprite = breaks[1];
            front.GetComponent<SpriteRenderer>().sprite = breaks[0];
            GetComponent<AudioSource>().Play();
        }
    }
}
