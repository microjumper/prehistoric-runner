using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip biteClip;

    private readonly float jumpForce = 10;

    private new Rigidbody2D rigidbody;
    private Animator animator;
    private AudioSource audioSource;

    private bool isJumping;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
            GameManager.instance.GameOver();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup") && !GameManager.IsGameOver)
        {
            audioSource.clip = biteClip;
            audioSource.Play();
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
                GameManager.instance.GameOver();
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
