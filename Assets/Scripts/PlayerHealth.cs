using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public Slider healthSlider;
    public float health = 100f;
    public float damage;
    public bool isDamaged;
    public float graceTime = 1f;
    float flashTimer = 0.25f;

    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isDamaged) {
            health -= damage;
            sprite.color = Color.red;
        }
        else {
            flashTimer -= Time.deltaTime;

            health += 0.075f;
            if (flashTimer <= 0) {
                sprite.color = Color.white;
                flashTimer = 0.25f;
            }
        }

        healthSlider.value = health;
        isDamaged = false;
    }

}
