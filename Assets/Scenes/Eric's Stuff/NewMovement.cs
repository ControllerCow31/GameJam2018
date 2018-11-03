using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour {
    public CameraShake cameraShake;
    public PlayerHealth health;

    AudioSource dashSound;
    Rigidbody2D playerRB;
    public float speed = 2f;
    public bool grounded;
    public bool dashIsCharging;
    public bool dashIsCooling;
    public bool dashUsedThisJump;
    public float dashTime;
    public float dashForce;
    public float cameraShakeMagnitude;
    public bool dashed;

    // Use this for initialization
    void Start() {
        playerRB = GetComponent<Rigidbody2D>();
        dashSound = GetComponent<AudioSource>();
        grounded = false;
        dashIsCharging = false;
        playerRB.mass = 2.5F;
        playerRB.gravityScale = 3;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded == true) {
            playerRB.AddForce(transform.up * 2000);
        }

        if (Input.GetKey(KeyCode.Space) && dashIsCooling == false && dashUsedThisJump == false) {
            dash();
        }
    }
    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            PlayerHealth.playerHealth -= 10;
            playerRB.AddForce(new Vector2(other.relativeVelocity.x * -20, 2));
        }
        grounded = true;
        dashUsedThisJump = false;
    }

    public void OnCollisionExit2D(Collision2D other) {
        grounded = false;
    }

    public void dash() {
        playerRB.velocity = Vector2.zero;
        if (Input.GetAxis("Horizontal") > 0) {
            playerRB.AddForce(transform.right * dashForce);
            StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
            dashSound.Play();
            
        }
        if (Input.GetAxis("Horizontal") < 0) {
            playerRB.AddForce(transform.right * -dashForce);
            StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
            dashSound.Play();
        }
        if (Input.GetAxis("Vertical") > 0) {
            playerRB.AddForce(transform.up * dashForce);
            StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
            dashSound.Play();

            dashUsedThisJump = true;
        }
        if (Input.GetAxis("Vertical") < 0) {
            playerRB.AddForce(transform.up * -dashForce);
            StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
            dashSound.Play();

            dashUsedThisJump = true;
        }

        health.isDamaged = true;
        dashIsCooling = true;
        StartCoroutine(dashCooldown());
    }

    public IEnumerator dashCooldown() {
        yield return new WaitForSeconds(0.2F);
        playerRB.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.3F);
        dashIsCooling = false;
    }
}
