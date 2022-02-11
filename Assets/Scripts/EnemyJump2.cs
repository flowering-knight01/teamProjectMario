using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump2 : MonoBehaviour
{
    public float speed;
    private int forwards = 1;

    //for counting the small jumps before big jump
    public int isJumping = 0;

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
                transform.position = new Vector2(transform.position.x, transform.position.y+(speed*5));
            }
            else if(isJumping >= 3)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y+(speed*5));
                isJumping = 0;
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x+speed, transform.position.y);

            if(isJumping < 3)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y+(speed*5));
            }
            else if(isJumping >= 3)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y+(speed*5));
                isJumping = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Check to see if the tag on the collider is the one being looked for
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
            isJumping += 1;
        }

        if (other.gameObject.tag == "dBox")
        {
            Destroy(gameObject);
        }
    }
}
