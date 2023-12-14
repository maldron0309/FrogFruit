using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJump;
    
    private bool isJumping;
    private bool isDeath = false;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        isJumping = false;
    }

    private void Update()
    {
        PlayerMove();
        PlayerJump();
        
        if(isDeath) return;
    }

    private void PlayerMove()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * playerSpeed, rb.velocity.y);

        if (Input.GetButton("Horizontal"))
            sr.flipX = Input.GetAxisRaw("Horizontal") == -1;

        if (rb.velocity.normalized.x == 0)
            anim.SetBool("isRun", false);
        else
            anim.SetBool("isRun", true);
    }

    /// <summary>
    /// Player Jump
    /// </summary>
    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);

            isJumping = true;
            anim.SetBool("isJump", true);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            anim.SetBool("isJump", false);
        }

    }

    public void Death()
    {
        isDeath = true;
        
        anim.SetTrigger("isDeath");
        Destroy(gameObject,1f);
    }

}