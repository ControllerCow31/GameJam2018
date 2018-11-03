using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {
	public float speed;
	public float distance;
    public GameObject enemy;
    public float enemyHealth = 10;
    public GameObject effect;

	private Transform target;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, target.position) > distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

            

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        HurtEnemy();
    }

    void HurtEnemy()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
