using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllwe : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State {Idle, running, jumping}
    private State state = State.Idle;
    private Collider2D coll;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
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
            anim.SetBool("running", true);
        }

        else
        {
            anim.SetBool("running", false);
        }

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            state = State.jumping;
        }

        VelocityState();
        anim.SetInteger("State", (int)state);
    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {

        }

        if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.running;
        }

        else if(rb.velocity.x < .1f)
        {
          
        }
        else
        {    //Being Still
            state = State.Idle;
        }
    }
}