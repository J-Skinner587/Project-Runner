using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllwe : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(x * Time.deltaTime * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
    }

}

