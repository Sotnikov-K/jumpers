using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator animator;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;

    private SpriteRenderer sprite;


    private enum MovementState { idle, running, jumping, falling };
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {

        //Raw дает мгновенный горизонтальный прирост скорости
        //Input.GetAxis дает числовое направление - влево вправо 

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }


    private void UpdateAnimationState()
    {
        MovementState state;

        //Debug.Log(dirX);
        //Debug.Log(rb.velocity.y);

        if (dirX > 0f)
        {
            state = MovementState.running;
            //animator.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            //animator.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
        {
            //animator.SetBool("Running", false);
            state = MovementState.idle;
        }


        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }


    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }



}
