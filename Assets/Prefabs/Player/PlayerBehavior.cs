using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
	
	public GameObject playerObject;
	public Rigidbody2D playerRB;
	public float speed;
	public bool grounded;
	public bool dashIsCharging;
	public float dashTime;
	public float startDashTime;
	public float dashSpeed;
	
	// Use this for initialization
	void Start () {
		playerRB = playerObject.GetComponent<Rigidbody2D>();
		grounded = false;
		speed = 5f;
		dashIsCharging = false;
		dashSpeed = 50;
		startDashTime = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

		if(Input.GetKeyDown(KeyCode.W) && grounded == true){
			playerRB.AddForce(transform.up*1000);
		}

		if(Input.GetKey(KeyCode.Space)){
			dash();
		}
	}
	public void OnCollisionEnter2D(Collision2D other){
		grounded = true;
	}

	public void OnCollisionExit2D(Collision2D other){
		grounded = false;
	}

	public void dash(){
		if (dashTime <= 0)
        {
            dashTime = startDashTime;
            playerRB.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (Input.GetButton("Horizontal") && Input.GetButtonDown("Jump"))
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    playerRB.velocity += Vector2.right * dashSpeed;
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    playerRB.velocity += Vector2.left * dashSpeed;
                }
            }

            if (Input.GetButton("Vertical") && Input.GetButtonDown("Jump"))
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    playerRB.velocity += Vector2.up * dashSpeed;
                }
                if (Input.GetAxis("Vertical") < 0)
                {
                    playerRB.velocity += Vector2.down * dashSpeed;
                }
            }
        }
	}
}
