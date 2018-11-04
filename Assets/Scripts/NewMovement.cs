using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour {
    public CameraShake cameraShake;
    public PlayerHealth health;
    public AudioClip dashSound;
    public AudioClip jumpSound;

    AudioSource playerSounds;
    Rigidbody2D playerRB;
    public float speed = 2f;
    public bool grounded;
    public bool dashIsCharging;
    public bool dashIsCooling;
    public bool dashUsedThisJump;
    public bool currentlyDashing;
    public float dashTime;
    public float dashForce;
    public float cameraShakeMagnitude;
    public bool dashed;

    // Use this for initialization
    void Start() {
        playerRB = GetComponent<Rigidbody2D>();
        playerSounds = GetComponent<AudioSource>();

        currentlyDashing = false;
        grounded = false;
        dashIsCharging = false;
        playerRB.mass = 2.5F;
        playerRB.gravityScale = 3;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        if ((Input.GetKeyDown("w") || Input.GetKeyDown("up") && grounded == true)) {
            playerRB.AddForce(transform.up * 2000);
            playerSounds.PlayOneShot(jumpSound);
        }

        if (Input.GetKey(KeyCode.Space) && dashIsCooling == false && dashUsedThisJump == false) {
            currentlyDashing = true;
            Debug.Log("currentlyDashing = " + currentlyDashing);
            dash();
        }
    }
    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
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
        playerRB.gravityScale = 0;
        if (Input.GetAxis("Horizontal") > 0) {
            playerRB.AddForce(transform.right * dashForce);
            StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
            playerSounds.Play();
            
        }
        if (Input.GetAxis("Horizontal") < 0) {
            playerRB.AddForce(transform.right * -dashForce);
            StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
            playerSounds.Play();
        }
        if (Input.GetAxis("Vertical") > 0) {
            playerRB.AddForce(transform.up * dashForce);
            StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
            playerSounds.Play();

            dashUsedThisJump = true;
        }
        if (Input.GetAxis("Vertical") < 0) {
            playerRB.AddForce(transform.up * -dashForce);
            StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
            playerSounds.Play();

            dashUsedThisJump = true;
        }
    
        dashIsCooling = true;
        StartCoroutine(dashCooldown());
    }

    public IEnumerator dashCooldown() {
        yield return new WaitForSeconds(0.2F);
        currentlyDashing = false;
        Debug.Log("currentlyDashing = " + currentlyDashing);
        playerRB.velocity = Vector2.zero;
        playerRB.gravityScale = 3;
        yield return new WaitForSeconds(0.3F);
        dashIsCooling = false;
    }
}
