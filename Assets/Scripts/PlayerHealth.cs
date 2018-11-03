using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


    public Slider healthSlider;
    public float playerHealth = 100f;
    public float damage = 25f;
    public bool isDamaged;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (isDamaged) {
            playerHealth -= damage;
            healthSlider.value = playerHealth;
        }
        else {
            healthSlider.value += .1f;
        }
        isDamaged = false;
    }
}
