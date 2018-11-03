using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
	
	public GameObject playerObject;
	public Rigidbody2D playerRB;
	public float speed;
	public bool grounded;
	public bool dashIsCharging;
	public bool dashIsCooling;
	public bool dashUsedThisJump;
	public float dashTime;
	public float startDashTime;
	public float dashForce;
	
	// Use this for initialization
	void Start () {
		playerRB = playerObject.GetComponent<Rigidbody2D>();
		grounded = false;
		speed = 5f;
		dashIsCharging = false;
		dashForce = 2500;
		startDashTime = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

		if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))&& grounded == true){
			playerRB.AddForce(transform.up*1000);
		}

		if(Input.GetKey(KeyCode.Space) && dashIsCooling == false && dashUsedThisJump == false){
			dash();
		}
	}
	public void OnCollisionEnter2D(Collision2D other){
		grounded = true;
		dashUsedThisJump = false;
	}

	public void OnCollisionExit2D(Collision2D other){
		grounded = false;
	}

	public void dash(){
		if(Input.GetAxis("Horizontal") > 0){
			playerRB.AddForce(transform.right*dashForce);
		}
		if(Input.GetAxis("Horizontal") < 0){
			playerRB.AddForce(transform.right*-dashForce);
		}
		if(Input.GetAxis("Vertical") > 0){
			playerRB.AddForce(transform.up*dashForce);
		}
		if(Input.GetAxis("Vertical") < 0){
			playerRB.AddForce(transform.up*-dashForce);
		}
		dashIsCooling = true;
		dashUsedThisJump = true;
		StartCoroutine(dashCooldown());
	}

	public IEnumerator dashCooldown(){
		yield return new WaitForSeconds(0.2F);
		playerRB.velocity = Vector2.zero;
		yield return new WaitForSeconds(0.3F);
		dashIsCooling = false;
	}
}
