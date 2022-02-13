using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    //purposefully left as neither public nor private
    GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //when hit, flip it over and drop it off screen
            //also, disable its colliders so that it doesn't get stuck
            
            //actually, not applicable anymore
            //just destroys enemy when head is hit

            Debug.Log("from head: head hit");

            //GetComponent<Collider2D>().enabled = false;

            //Enemy.GetComponent<SpriteRenderer>().flipY = true;
            //Enemy.GetComponent<Collider2D>().enabled = false;

            //Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
            //Enemy.transform.position += movement * Time.deltaTime;

            //Destroy(Enemy.GetComponent<DeathBoxScript>());
            Destroy(Enemy.gameObject);
        }
    }
}
