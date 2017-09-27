using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {
    public float fallVel = 2.5f;
    public float lowJump = 2f;

    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jump = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallVel - 1) * Time.deltaTime;
            }

            else if (rb.velocity.y > 0 && !jump)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJump - 1) * Time.deltaTime;
            }
    }
}
