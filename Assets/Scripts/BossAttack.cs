using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject bulletPrefab;
    public float bulletVelocity;
    public int numberOfProjectiles = 8;
    public float timeBetweenAttack = 1f;

    const float radius = 1f;
    Vector2 spawnPos;


	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
           // StartCoroutine(playerPrefab.Knockback(0.02f, 350f,playerPrefab.transform));
        }
    }

    // Update is called once per frame
    void Update () {
        if (timeBetweenAttack <= 0) {
            spawnPos = transform.position;
            spawnProjectile(numberOfProjectiles);
            timeBetweenAttack = 3f;
        }
        else {
            timeBetweenAttack -= Time.deltaTime;
        }
	}

    void spawnProjectile(int numberOfProjectiles) {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles-1; i++) {
            float xDirection = spawnPos.x + Mathf.Sin((angle * Mathf.PI) /180) * radius;
            float yDirection = spawnPos.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(xDirection, yDirection);
            Vector2 projMoveDirection = (projectileVector - spawnPos).normalized * bulletVelocity;

            GameObject temp = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(projMoveDirection.x, projMoveDirection.y);

            angle += angleStep;
        }
    }

    public IEnumerator Knockback(float knockBackDuration, float knockBackPower, Vector2 knockBackDirection) {
        float timer = 0;

        while (knockBackDuration < timer) {
            timer += Time.deltaTime;
            playerPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockBackDirection.x * -100, knockBackDirection.y * knockBackPower));
        }

        yield return null;

    }
}
