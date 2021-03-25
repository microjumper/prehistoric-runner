using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly float jumpForce = 10;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    private bool isJumping;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        isJumping = false;
    }

    void Update()
    {
        if(rigidbody.velocity.y < 0)
        {
            rigidbody.gravityScale = 3;
        }

        if(transform.position.x < 0)
        {
            animator.SetTrigger("hit");
        }
    }

    public void OnJump()
    {
        if(!isJumping)
        {
            rigidbody.gravityScale = 2;

            isJumping = true;
            animator.SetBool("isJumping", isJumping);

            animator.SetTrigger("jump");
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if(isJumping)
            {
                Ground();
            }
            else
            {
                animator.SetTrigger("hit");
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Ground();
        }
    }

    private void Ground()
    {
        rigidbody.gravityScale = 2;

        isJumping = false;
        animator.SetBool("isJumping", isJumping);
    }
}
