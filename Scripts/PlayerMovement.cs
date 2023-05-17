using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rb ;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    private float dirXtouch =0f;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;

    private enum MovementState { idle, running, jumping, falling, climbing}
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            dirXtouch = touch.position.x - Screen.width / 2;
            dirXtouch /= Screen.width / 2;

            if (Mathf.Abs(dirXtouch) > Mathf.Abs(dirX))
            {
                dirX = dirXtouch*1.5f;
            }
        }

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.deltaPosition.y > 0 && IsGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if(dirX>0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(dirX<0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else    
            state = MovementState.idle;

        if(rb.velocity.y >.1f)
            state = MovementState.jumping;
        else if(rb.velocity.y <-.1f)
            state = MovementState.falling;
            
        anim.SetInteger("state",(int)state );
    }
    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
