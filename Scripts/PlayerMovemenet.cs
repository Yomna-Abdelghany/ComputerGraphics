using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemenet : MonoBehaviour
{
    private Animator anim;
    Rigidbody rb;


    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    private enum MovementState { idle, walking, jumping}



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseXValue = Input.GetAxis("Mouse X");
        float mouseYValue = Input.GetAxis("Mouse Y");



        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(2)) && IsGrounded())
        {
            Jump();
        }

        UpdateAnimationState();
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }


    private void UpdateAnimationState()
    {
        MovementState state;


        if(rb.velocity.x==0f && rb.velocity.z==0f)
        {
            state=MovementState.idle;
        }
        else if(rb.velocity.x>.1f || rb.velocity.z>.1f)
        {
            state=MovementState.walking;
        }
        else
        {
            state=MovementState.idle;
        }

        if(rb.velocity.y>.1f)
        {
            state = MovementState.jumping;
        }

        anim.SetInteger("state",(int)state);
    }



    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    } 
}
