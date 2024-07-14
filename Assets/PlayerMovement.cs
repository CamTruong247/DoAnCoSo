using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public Animator animator;

    public AudioManager audioManager;

    [Header("Attributes")]
    [SerializeField] public float speed = 12f;
    [SerializeField] private float jumpingPower = 10f;

    public static PlayerMovement main;
    private float horizontal;
    private bool isWalking = false;


    private void Awake()
    {
        main = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if(Time.timeScale == 1)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                animator.SetBool("Jumping", true);
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
            if (IsGrounded() && horizontal != 0)
            {
                if (!isWalking)
                {
                    audioManager.PlayWalkSFX();
                    isWalking = true;
                }
            }
            else
            {
                if (isWalking)
                {
                    audioManager.StopWalkSFX();
                    isWalking = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("Speed", MathF.Abs(horizontal));
        animator.SetFloat("Height", rb.velocity.y);
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Jumping", false);
    }
}
