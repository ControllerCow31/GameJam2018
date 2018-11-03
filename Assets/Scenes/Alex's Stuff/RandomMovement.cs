using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
    public GameObject enemy;
    public float spawnTime = 1f;
    public float betweenSpawn = 0f;


    // Update is called once per frame
    void Update () {
        betweenSpawn += Time.deltaTime;

        if (betweenSpawn >= spawnTime)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            betweenSpawn = 0;
        }
    }
}
