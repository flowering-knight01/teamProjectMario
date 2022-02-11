using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonFire : MonoBehaviour
{

    public float shoot = 20.0f;
    public float untilShoot;
    public GameObject cannonball;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(untilShoot <= 0)
        {
            Instantiate(cannonball, firePoint.position, firePoint.rotation);
            untilShoot = shoot;
        }
        else
        {
            untilShoot -= Time.deltaTime;
        }
    }
}
