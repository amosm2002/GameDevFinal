using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animat;
    private float dirX = 0f;
    public float moveSpeed = 7f;
    public float jumpForce = 14f;
    private enum MovementState { idel, running, jumping, falling }
    private MovementState state = MovementState.idel;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animat = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            animat.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            animat.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            animat.SetBool("running", false);
        }
    }
}
