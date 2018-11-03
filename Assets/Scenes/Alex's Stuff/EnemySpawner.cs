using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public float spawnTime = 1f;
	public float elapsedTime = 0f;

	public GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if (elapsedTime > spawnTime)
		{
			Instantiate(enemy, transform.position, Quaternion.identity);
			elapsedTime = 0;
		}
	}
}
