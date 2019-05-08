using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool facingRight = true;
    private Rigidbody2D rigi;
    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float jumpForce = 700f;
    void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapBox(groundCheck.position, groundCheck.localScale, 90, whatIsGround);

        float moveHor = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(moveHor));

        rigi.velocity = new Vector2(moveHor * maxSpeed, rigi.velocity.y);

        if(moveHor > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveHor < 0 && facingRight)
        {
            Flip();
        }
    }

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigi.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
