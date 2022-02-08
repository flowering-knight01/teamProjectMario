using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public bool winCheck;
    void Start ()
    {
    winCheck = false;
    }
    void Update ()
    {
    if (winCheck == true)
    {
    StartCoroutine(Win()); 
    }
    }
    IEnumerator Win()
    {
         yield return new WaitForSeconds(2);
          SceneManager.LoadScene(SceneManager.sceneCount +1);
    }
}
