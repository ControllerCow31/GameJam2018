using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {
    public AudioClip bossDamage;
    public Slider bossHealthSlider;
    public float health = 100f;
    public float damage = 5f;
    public bool isDamaged;
    float flashTimer = 0.25f;
    float gracePeriod = 1f;

    AudioSource bossAudio;
    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        bossAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (isDamaged) {
            health -= damage;
            bossHealthSlider.value = health;
            sprite.color = Color.red;
            bossAudio.PlayOneShot(bossDamage);
        }
        else {
            flashTimer -= Time.deltaTime;
            if (flashTimer <= 0) {
                sprite.color = Color.white;
                flashTimer = 0.25f;
            }
        }

        isDamaged = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (collision.gameObject.GetComponent<NewMovement>().currentlyDashing == true) {
                isDamaged = true;
            }
            else {
                collision.gameObject.GetComponent<PlayerHealth>().isDamaged = true;
            }
        }
    }
}
