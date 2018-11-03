using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    public CameraShake cameraShake;

    Rigidbody2D playerRigidBody;

    float dashTime;
    float moveHorizontal;
    float moveVertical;

    public float moveSpeed;
    public float dashSpeed;
    public float startDashTime;
    public float cameraShakeMagnitude;

    // Use this for initialization
    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        playerRigidBody.velocity = new Vector2(moveHorizontal * moveSpeed, playerRigidBody.velocity.y);

        if (dashTime <= 0)
        {
            //Limit use of dashes with timer
            dashTime = startDashTime;
            playerRigidBody.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;
            //Dash Left & Right
            if (Input.GetButton("Horizontal") && Input.GetButtonDown("Jump"))
            {
                if (moveHorizontal > 0)
                {
                    playerRigidBody.velocity += Vector2.right * dashSpeed;
                    StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
                }
                if (moveHorizontal < 0)
                {
                    playerRigidBody.velocity += Vector2.left * dashSpeed;
                    StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));
                }
            }

            //Dash Up & Down
            if (Input.GetButton("Vertical") && Input.GetButtonDown("Jump"))
            {
                if (moveVertical > 0)
                {
                    playerRigidBody.velocity += Vector2.up * dashSpeed;
                    StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));

                }
                if (moveVertical < 0)
                {
                    playerRigidBody.velocity += Vector2.down * dashSpeed;
                    StartCoroutine(cameraShake.Shake(dashTime, cameraShakeMagnitude));

                }
            }
        }
    }
}
