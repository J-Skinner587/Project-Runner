using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllwe : MonoBehaviour
{

    // Basic Variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    private AudioSource footstep;



    //FSM (finite state machine)
    private enum State { Idle, running, jumping, falling }
    private State state = State.Idle;





    //Inspector Variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Movement();
        AnimationState();
        anim.SetInteger("State", (int)state); //Sets animation based on enum state
    }

    private void Movement()
    {

        float hDirection = Input.GetAxis("Horizontal");

        //Left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-10, 10);
        }

        //Right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(10, 10);
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            state = State.jumping;
        }

    }

    private void AnimationState()
    {
        if (state == State.jumping)
        {
            //Jumping
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.Idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.running;
        }

        else
        {    //Being Still
            state = State.Idle;
        }
    }
}