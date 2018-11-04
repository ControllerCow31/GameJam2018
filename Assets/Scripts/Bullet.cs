using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    PlayerHealth playerHealth;
    public float bulletLife = 10f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (bulletLife <= 0) {
            Destroy(gameObject);
        }
        else {
            bulletLife -= Time.deltaTime;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Collided");
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.isDamaged = true;
            Destroy(gameObject);
        }
    }
}
