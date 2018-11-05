using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {

    public PlayerKnockback playerKnock;
    public GameObject bulletPrefab;
    public float bulletVelocity;
    public int numberOfProjectiles = 8;
    public float timeBetweenAttack = 3f;

    const float radius = 1f;
    Vector2 spawnPos;
    Animator anim;
    SpriteRenderer bossSprite;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        bossSprite = GetComponent<SpriteRenderer>();
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        // Knockback the player when touching boss
        if (collision.gameObject.tag == "Player") {

            StartCoroutine(playerKnock.Knockback(0.02f, 250, playerKnock.transform.position));

        }
    }

    // Update is called once per frame
    void Update () {
        // Bullets are shot at set time intervals
        if (timeBetweenAttack <= 0) {
            anim.SetBool("isAttacking", true);
            spawnPos = transform.position;
            spawnProjectile(numberOfProjectiles);
            timeBetweenAttack = 3f;
        }
        else {
            timeBetweenAttack -= Time.deltaTime;

            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Boss_Attack")) {
                anim.SetBool("isAttacking", false);
            }
        }
    }

    // Spawns bullets in a radial pattern
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
}
