using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public Slider healthSlider;
    public float health = 100f;
    public float damage;
    public bool isDamaged;
    public float graceTime;
    float flashTimer = 0.25f;

    private float damageTimer; 

    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        damageTimer = graceTime; 
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isDamaged && damageTimer <= 0) {
            health -= damage;
            damageTimer = graceTime; 
            sprite.color = Color.red;
        }
        else {
            flashTimer -= Time.deltaTime;
            damageTimer -= Time.deltaTime; 
            if (health < 100) {
                health += 0.075f;
            }

            if (flashTimer <= 0) {
                sprite.color = Color.white;
                flashTimer = 0.25f;
            }
        }

        healthSlider.value = health;
        isDamaged = false;
    }

}
