using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
 public static float speed = 2;
 
 void Start()
 {
     speed = 2;
 }
    void FixedUpdate()
     {
        if (Time.deltaTime < 90)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }
}
