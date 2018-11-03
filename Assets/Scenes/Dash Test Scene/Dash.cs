using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    public CameraShake cameraShake;

    Rigidbody2D playerRigidBody;

    float dashTime;
    float moveHorizontal;
    float moveVertical;
    bool isGrounded;
    bool isDashing;

    public float moveSpeed;
    public float dashSpeed;
    public float startDashTime;

    // Use this for initialization
    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        playerRigidBody.velocity = new Vector2(moveHorizontal * moveSpeed, playerRigidBody.velocity.y);

        if (dashTime <= 0)
        {
            dashTime = startDashTime;
            playerRigidBody.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (Input.GetButton("Horizontal") && Input.GetButtonDown("Jump"))
            {
                if (moveHorizontal > 0)
                {
                    playerRigidBody.velocity += Vector2.right * dashSpeed;
                }
                if (moveHorizontal < 0)
                {
                    playerRigidBody.velocity += Vector2.left * dashSpeed;
                }
            }

            if (Input.GetButton("Vertical") && Input.GetButtonDown("Jump"))
            {
                if (moveVertical > 0)
                {
                    playerRigidBody.velocity += Vector2.up * dashSpeed;
                }
                if (moveVertical < 0)
                {
                    playerRigidBody.velocity += Vector2.down * dashSpeed;
                }
            }
        }
    }
}
