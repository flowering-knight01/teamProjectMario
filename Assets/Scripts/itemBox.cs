using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBox : MonoBehaviour
{
    public bool hasItem;

    public GameObject item;

    public GameObject coin;

    public Transform iBox;

    GameObject theParent;

    void Start()
    {
        theParent = gameObject.transform.parent.gameObject;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(hasItem == true)
            {
                Instantiate(item, iBox.position, Quaternion.identity);
                Debug.Log("from itemBox: player hit");
                Destroy(theParent.gameObject);
            }
            else
            {
                Instantiate(coin, iBox.position, Quaternion.identity);
                Debug.Log("from itemBox: no item");
                Destroy(theParent.gameObject);
            }
        }
    }
}
