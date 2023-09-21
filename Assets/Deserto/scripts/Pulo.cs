using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    public Animator animator;
    public Control playerScript;

    bool jumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false && playerScript.cutscene <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("Jump", true);
            jumping = true;
        }

         void OnJumpAnimationFinished()
        {
           animator.SetBool("Jump", false);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
        animator.SetBool("Jump", false);
    }
}
