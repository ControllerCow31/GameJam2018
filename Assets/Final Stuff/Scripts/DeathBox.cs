using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Invoke("ReloadLevel", 1);  
        }
    }

    void ReloadLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
