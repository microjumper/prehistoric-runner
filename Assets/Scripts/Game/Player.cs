using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly float jumpForce = 7;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    private bool isJumping;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
    }

    void Update()
    {
        animator.SetFloat("yVelocity", rigidbody.velocity.y);
    }

    public void OnJump()
    {
        if(!isJumping)
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);

            animator.SetTrigger("jump");
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !isJumping)
        {
            animator.SetTrigger("hit");
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
        }
    }
}
