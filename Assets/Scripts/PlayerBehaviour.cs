using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public enum State { Default, Dead, GodMode }
    public State state;

    [Header("State")]
    public bool canJump = true;
    public bool isJumping = false;

    public bool isGrounded;
    public bool wasGroundedLastFrame;
    public bool justGotGrounded;
    public bool justNotGrounded;
    public bool isFalling;

    [Header("Filter")]
    public ContactFilter2D filter;
    public int maxColliders = 1;
    public bool checkGround = true;

    [Header("Box properties")]
    public Vector2 groundBoxPos;
    public Vector2 groundBoxSize;

    [Header("Physics")]
    public Rigidbody2D rb;

    [Header("Forces")]
    public float jumpForce;

    private void FixedUpdate()
    {
        ResetState();
        GroundDetection();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            JumpStart();
        }
    }

    void ResetState()
    {
        wasGroundedLastFrame = isGrounded;
        isFalling = !isGrounded;

        isGrounded = false;
        justNotGrounded = false;
        justGotGrounded = false;
    }

    void GroundDetection()
    {
        if(!checkGround) return;

        Vector3 pos = this.transform.position + (Vector3)groundBoxPos;
        Collider2D[] results = new Collider2D[maxColliders];

        int numColliders = Physics2D.OverlapBox(pos, groundBoxSize, 0, filter, results);

        if(numColliders > 0)
        {
            isGrounded = true;
        }

        if(!wasGroundedLastFrame && isGrounded) justGotGrounded = true;
        if(wasGroundedLastFrame && !isGrounded) justNotGrounded = true;

        if(justNotGrounded) Debug.Log("JUST NOT GROUNDED");
        if(justGotGrounded) Debug.Log("just got grounded");

        if(isJumping)
        {
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Jump()
    {
        isJumping = true;
    }

    public void JumpStart() //Decidir como será el salto
    {
        if(!canJump) return;

        if(isGrounded)
        {
            Jump();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 groundPos = this.transform.position + (Vector3)groundBoxPos;
        Gizmos.DrawWireCube(groundPos, groundBoxSize);
    }
}
