using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
	private float speed;
	public float distance;
    public GameObject particleEffect;
    public float enemyHealth = 10;  
    public GameObject corpse;

	private bool movingRight = true;

	public Transform groundDetection;
	// Use this for initialization
	void Start () {
		speed = Random.Range(2, 5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * speed * Time.deltaTime);

		RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

		if (groundInfo.collider == false)
		{
			if (movingRight == true)
			{
				transform.eulerAngles = new Vector3(0, -180, 0);
				movingRight = false;
			}
			else
			{
				transform.eulerAngles = new Vector3(0, 0, 0);
				movingRight = true;
			}

		}
		

	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HurtEnemy();
        }
    }

    void HurtEnemy()
    {
        Instantiate(particleEffect, transform.position, Quaternion.identity);
        enemyHealth -= 5;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(corpse, transform.position, Quaternion.Euler(180, 0, 0));
        }
    }
}
