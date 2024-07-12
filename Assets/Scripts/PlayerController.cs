using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private Vector3 originalScale;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalScale = new Vector3(4, 4, 4); // Aseguramos que la escala inicial sea 4

    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Controlar la animación
        if (move != 0)
        {
            animator.SetBool("isWalking", true);
            transform.localScale = originalScale;

        }
        else
        {
            animator.SetBool("isWalking", false);
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);

        }

        // Voltear el sprite según la dirección del movimiento
        if (move > 0)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
        // Saltar
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
           // animator.SetBool("isJumping", true);
            isJumping = true;
        }

        // Comprobar si el personaje ha aterrizado
        if (rb.velocity.y == 0)
        {
            //animator.SetBool("isJumping", false);
            isJumping = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Suelo"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Elevator"))
        {
            // Hacer al jugador hijo de la plataforma
            this.transform.parent = collision.transform;
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Suelo"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("Elevator"))
        {
            // Desvincular al jugador de la plataforma
            this.transform.parent = null;
        }
    }
}
