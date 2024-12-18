using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float maxSpeed = 10f;
    public float jumpForce = 10f;
    private bool isJumping = false;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private Rigidbody2D rb;
    public Animator animator; // Variable p�blica para el componente Animator

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("No se encontr� el Rigidbody2D en el personaje.");
            return;
        }

        // Inicializar el Animator
        animator = GetComponent<Animator>();

        // Asegurarse de que el Rigidbody2D est� configurado correctamente
        rb.gravityScale = 1; // Ajusta seg�n tus necesidades
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Impide que el personaje gire
    }

    private void Update()
    {
        CheckGround();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Aplicar fuerza en el eje X si la velocidad actual es menor que la m�xima
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(new Vector2(horizontalInput * moveSpeed, 0), ForceMode2D.Impulse);
        }

        // Configurar el par�metro de velocidad en el Animator
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }

        // Voltea el sprite al moverse a la izquierda o derecha
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && isJumping)
        {
            isJumping = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
