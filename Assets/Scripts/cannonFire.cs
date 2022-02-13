using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonFire : MonoBehaviour
{

    private float shoot;
    private float untilShoot;
    public GameObject cannonball;
    public Transform firePoint;


    void Start()
    {
        shoot = Random.Range(3.0f, 3.5f);
        untilShoot = shoot;
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
