using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    public Animator animator;

    bool jumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("Jump", true);
            jumping = true;
        }

        else
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetAxis("Cair") != 0)
        {
            animator.SetBool("Caindo", true);
        }

        else
        {
            animator.SetBool("Caindo", false);
        }
        if (Input.GetAxis("Jump") != 0)
        {
            animator.SetBool("Pulosla", true);
        }

        else
        {
            animator.SetBool("Pulosla", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }
}
