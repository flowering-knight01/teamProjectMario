using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpeed : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 4.0f);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
