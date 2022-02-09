using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private int forwards = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(forwards == 1)
        {
            transform.position = new Vector2(transform.position.x-speed, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x+speed, transform.position.y);
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
    }
}