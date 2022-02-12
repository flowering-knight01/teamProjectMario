using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBoxScript : MonoBehaviour
{
public bool deathCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        deathCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (deathCheck == true)
        {
            StartCoroutine(Death());
            //GameOverScript.loseCheck = true;
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
