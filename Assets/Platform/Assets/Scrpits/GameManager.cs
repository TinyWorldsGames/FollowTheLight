using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;
    private float x;
    public float jumpForce;
    private bool isGrounded = false;
    public Transform isGroundedChecker;
    private float checkGroundRadius = 0.05f;
    public LayerMask groundLayer;
    private float rememberGroundedFor = 0.3f;
    public float lastTimeGrounded;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();
        BetterJump();
        Debug.Log(animator.GetBool("isJump"));
        if (x == 0)
        {
              animator.SetBool("isWalking", false); 
        }
        else 
        {
              animator.SetBool("isWalking", true);
        }
    }
    void Move()
    {


        


        if (Input.GetKey(KeyCode.D))
        {
            x = 1;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
           
        }
        else if (Input.GetKey(KeyCode.A))
        {
            x = -1;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);


        }
        else
        {
            x = 0;
        }
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);


    }
    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            animator.SetBool("isJump", true);
            Debug.Log("True oldu");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        //if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        //{
        //   rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //  //  rb.AddForce(transform.up*jumpForce*50);
        //}
    }


    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        //if (colliders != null)
        //{
        //    isGrounded = true;
        //}
        //else
        //{
        //    if (isGrounded)
        //    {
        //        lastTimeGrounded = Time.time;
        //    }
        //    isGrounded = false;
        //}
        if (collider != null)
        {
            isGrounded = true;
           
        }
        else
        {
          
            isGrounded = false;
        }
    }
    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    //void JumpLoop()
    //{
    //    animator.SetBool("isJump", false);
    //    animator.SetBool("isFirstTouch", true);

    //}

}
