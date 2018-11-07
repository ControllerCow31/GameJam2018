using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    public PlayerHealth playerHealth; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (playerHealth.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
