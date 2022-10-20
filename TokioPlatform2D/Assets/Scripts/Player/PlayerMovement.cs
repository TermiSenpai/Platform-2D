using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    [SerializeField, Tooltip("Foot checker position")] private Transform groundCheck;
    [SerializeField, Tooltip("Front checker position")] private Transform wallCheck;
    [SerializeField, Tooltip("Ground Layer for physics detection")] private LayerMask groundLayer;
    [Space]
    [Header("Properties")]
    [SerializeField, Tooltip("Player movement speed")] private float speed;
    [SerializeField, Tooltip("Player jumping force")] private float jumpingPower;
    private float horizontal;
    private bool isFacingRight = true;
    private bool canMove = true;

    #region Getters

    public Rigidbody2D GetPlayerRb()
    {
        return rb;
    }

    public bool GetIsFacingRight()
    {
        return isFacingRight;
    }

    #endregion

    #region unity methods

    private void Start()
    {
        // get player rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            playerMove();

            playerTryFlip();
        }
        else rb.velocity = Vector2.zero;

    }
    #endregion

    #region private methods

    // Detect if player is touching the floor with physics and layer
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    // Detect if player is touching a wall with physics and layer
    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, groundLayer);
    }

    // Flip the player to the correct direction
    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void playerMove()
    {
        // If player is facing a wall, he cant move
        if (!isWalled())
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void playerTryFlip()
    {
        // player facind left or right
        if (!isFacingRight && horizontal > 0f)
            flip();
        else if (isFacingRight && horizontal < 0f)
            flip();
    }

    #endregion

    #region public methods

    public bool CanMove()
    {
        return canMove;
    }
    #endregion

    #region Setters

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    #endregion

    #region inputActions

    // Read the movement actions and set the value to work with it
    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;

    }

    // Read the jumping button and jump if is posible
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    #endregion
}
