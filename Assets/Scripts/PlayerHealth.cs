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


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (isDamaged) {
            health -= damage;
        }
        else {
            healthSlider.value += .1f;
            health += 0.075f;
        }

        healthSlider.value = health;
        isDamaged = false;
    }

}
