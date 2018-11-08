using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {
	public float speed;
	public float distance;
    public GameObject enemy;
    public float enemyHealth = 10;
    public GameObject effect;
    public GameObject corpse;
    public GameObject playerBlood;
    public PlayerHealth health;
    public GameObject player;

	private Transform target;

	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, target.position) > distance && Vector2.Distance(transform.position, target.position) < 18)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
        }
        
        if (target.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }



    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<NewMovement>().currentlyDashing == true)
            {
                HurtEnemy();
            }
            else
            {
                HurtPlayer();
            }
        }
        
    }

    void HurtEnemy()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        enemyHealth -= 5;

        if (enemyHealth <= 0)
        {
            Instantiate(corpse, transform.position, Quaternion.Euler(180, 0, 0));
            Destroy(gameObject);
        }

    }

    void HurtPlayer()
    {
        Instantiate(playerBlood, player.transform.position, Quaternion.identity);

        health.isDamaged = true;
    }
}
