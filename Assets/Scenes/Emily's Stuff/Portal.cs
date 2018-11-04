using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("it worked"); 
            SceneManager.LoadScene("Boss");
            //Invoke("ReloadLevel", 1);  
        }
    }
}
