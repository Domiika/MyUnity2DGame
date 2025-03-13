using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Rychlost pohybu hráče

    private Rigidbody2D rb; // Odkaz na Rigidbody2D komponentu
    private Vector2 movement; // Vektor pohybu hráče
    private SpriteRenderer spriteRenderer; // Odkaz na SpriteRenderer hráče
    private Animator animator; // Odkaz na Animator komponentu

    void Start()
    {
        // Automaticky získá potřebné komponenty
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        UpdateAnimator();
        FlipSprite();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void FlipSprite()
    {
        if (movement.x != 0)
        {
            spriteRenderer.flipX = movement.x < 0;
        }
    }

    void UpdateAnimator()
    {
        animator.SetFloat("xVelocity", movement.x);
        animator.SetFloat("yVelocity", movement.y);
    }
}