using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public PlayerHealth playerHealth;
    public BossHealth bossHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth.health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (bossHealth.health <= 0) {
            //You win!!
        }
	}
}
