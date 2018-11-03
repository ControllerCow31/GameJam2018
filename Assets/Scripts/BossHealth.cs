using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

    public Slider bossHealthSlider;
    public static float bossHealth = 100f;
    public float damage = 5f;
    public bool isDamaged;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDamaged) {
            bossHealth -= damage;
            bossHealthSlider.value = bossHealth;
        }

        isDamaged = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            isDamaged = true;
        }
    }
}
