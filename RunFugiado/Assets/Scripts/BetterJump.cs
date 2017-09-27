using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {
    public float fallVel = 2.5f;
    public float lowJump = 2f;

    Rigidbody2D rb;

    public ButtonSelect button;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        button = GameObject.Find("ButtonSelect").GetComponent<ButtonSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.Up == "W")
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallVel - 1) * Time.deltaTime;
            }

            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W) || rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJump - 1) * Time.deltaTime;
            }
        }

        if (button.Up == "UpArrow")
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallVel - 1) * Time.deltaTime;
            }

            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow) || rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJump - 1) * Time.deltaTime;
            }
        }
    }
}
