using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    public PlayerHealth playerHealth; 

	// Update is called once per frame
	void Update () {
       if (playerHealth.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
    }
}
