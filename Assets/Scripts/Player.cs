using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJump;

    private int jumpCount; // 수정: int 타입으로 변경
    private bool isJumping;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        isJumping = false;
        jumpCount = 0; // 수정: jumpCount 초기화
    }

    private void Update()
    {
        PlayerMove();
        PlayerJump();
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

    private void PlayerJump()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // 수정: Y 속도 초기화
            rb.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);
            jumpCount++;
            anim.SetBool("isJump", true);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            jumpCount = 0; // 수정: 점프 가능한 상태로 초기화
            anim.SetBool("isJump", false);
        }
    }
}