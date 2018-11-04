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
            healthSlider.value = health;
        }
        else {
            healthSlider.value += .1f;
        }
        isDamaged = false;
    }

}
