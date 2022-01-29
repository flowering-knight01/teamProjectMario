using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rd2d;
      float horizontal;
    float vertical;
    public float speed;

    private float getInput;
    public float jumpForce;

    private bool onGround;

    public Transform feetPosition;

    public Transform topPosition;
    public float Radius;

    public LayerMask groundCheck;

    private float jumpCounter;
    public float jumpTime;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

void FixedUpdate()
{
     getInput = Input.GetAxisRaw("Horizontal");
        rd2d.velocity = new Vector2(getInput * speed, rd2d.velocity.y);
}
    // Update is called once per frame
    void Update()
    {
         onGround = Physics2D.OverlapCircle(feetPosition.position, Radius, groundCheck);

        if(onGround == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpCounter = jumpTime;
            rd2d.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
                if(Input.GetKey(KeyCode.W))
        {
           if(jumpCounter > 0 && isJumping == true)
           {
                rd2d.velocity = Vector2.up * jumpForce;
                jumpCounter -= Time.deltaTime;
           }
           else
           {
               isJumping = false;
           }
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
    }
}
