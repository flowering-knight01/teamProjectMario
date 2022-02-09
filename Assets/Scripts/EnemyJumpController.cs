using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpController : MonoBehaviour
{
    public float speed;
    private int forwards = 1;

    //for counting the small jumps before big jump
    public int isJumping = 0;
    //public int inAir = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(forwards == 1)
        {
            transform.position = new Vector2(transform.position.x-speed, transform.position.y);

            
            if(isJumping < 3)
            {
                //inAir == 1
                transform.position = new Vector2(transform.position.x, transform.position.y+(speed*2));
                //isJumping += 1;
                //inAir = inAir*-1;
                Debug.Log(isJumping + " currently jumping");
            }
            else if(isJumping >= 3)
            {
                //&& inAir == 1
                transform.position = new Vector2(transform.position.x, transform.position.y+(speed*15));
                Debug.Log("big jump");
                isJumping = 0;
                //inAir = inAir*-1;
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x+speed, transform.position.y);

            if(isJumping < 3)
            {
                //inAir == 1
                transform.position = new Vector2(transform.position.x, transform.position.y+(speed*2));
                //isJumping += 1;
                //inAir = inAir*-1;
                Debug.Log(isJumping + " currently jumping");
            }
            else if(isJumping >= 3)
            {
                //&& inAir == 1
                transform.position = new Vector2(transform.position.x, transform.position.y+(speed*15));
                Debug.Log("big jump");
                isJumping = 0;
                //inAir = inAir*-1;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.gameObject.tag == "wall")
        {
            forwards = forwards*-1;
            Debug.Log("hit wall");
        }
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit player");
        }
        
        if(other.gameObject.tag == "floor")
        {
            //inAir = inAir*-1;
            isJumping += 1;
        }
        
    }
}
