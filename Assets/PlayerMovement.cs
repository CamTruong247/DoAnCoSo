using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator runningspeed;

    [Header("Attributes")]
    [SerializeField] private float speed = 12f;
    [SerializeField] private float jumpingPower = 10f;

    private float horizontal;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            runningspeed.SetFloat("Speed", MathF.Abs(horizontal));
            if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
            if (horizontal != 0)
            {
                if (horizontal > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

            }
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
