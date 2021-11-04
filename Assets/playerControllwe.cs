using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllwe : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State {Idle, Running, jumping}
    private State state = State.Idle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");
        
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-10, 10);
            anim.SetBool("Running", true);
        }

        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(10, 10);
            anim.SetBool("Running", true);
        }

        else
        {
            anim.SetBool("Running", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }

        VelocityState();
        anim.SetInteger("State", (int)state);
    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {

        }

        if(Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            //Going Right
            state = State.Running;
        }

        else if(rb.velocity.x < .1f)
        {
            //going left
        }
    }
}