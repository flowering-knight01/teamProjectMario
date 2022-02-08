using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rd2d;
    public float speed;
    private Vector2 velocity;

    //for jumping enemies
    public float jumpTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(1.75f, 1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x-speed, transform.position.y);
    }
}