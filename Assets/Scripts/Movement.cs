using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Variable")]
    [SerializeField] float speed=250f;
    [SerializeField] float jumpForce =250f;
    private float xInput,yInput;
    [SerializeField] float maxVelocity = 2f;

    
    [SerializeField] bool facingRight = true;
    [SerializeField] bool isJumping = true;
    

    [Header("Ground")]
    [SerializeField] float range = 1f;
   
  
    [Header("Component")]
    public Rigidbody2D rigidbody2D;
    [SerializeField] bool isGrounded = true;




    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*rigidbody2D.AddForce(new Vector2(speed * Time.deltaTime, rigidbody2D.velocity.y));

        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, jumpForce));
        }*/

        float forceX = 0f, forceY = 0f;
        float velocity = Mathf.Abs(rigidbody2D.velocity.x);

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (xInput > 0)
        {
            if (velocity < maxVelocity)
                forceX = speed * Time.fixedDeltaTime;
        }
        else if (xInput < 0)
        {
            if (velocity < maxVelocity)
                forceX = -speed * Time.fixedDeltaTime;
        }

        if (yInput > 0f)
        {
            if (isGrounded && !isJumping)
            {
                isJumping = true;
                forceY = jumpForce;
            }
        }
        else
            isJumping = false;

        rigidbody2D.AddForce(new Vector2(forceX, forceY * Time.fixedDeltaTime));


        rigidbody2D.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);

   

        if (xInput > 0 && !facingRight)
        {
            FlipCharcter();
        }
        else if (xInput < 0 && facingRight)
        {
            FlipCharcter();
        }

    }
    void FlipCharcter()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }

}
