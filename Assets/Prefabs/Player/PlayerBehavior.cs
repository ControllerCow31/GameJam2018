using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
	
	public GameObject playerObject;
	public Rigidbody2D playerRB;
	public bool grounded;
	// Use this for initialization
	void Start () {
		playerRB = playerObject.GetComponent<Rigidbody2D>();
		grounded = false;
	}
	
	// Update is called once per frame
	void Update () {
		float speed = 5f;
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

		if(Input.GetKeyDown(KeyCode.W) && grounded == true){
			playerRB.AddForce(transform.up*400);
		}
	}
	public void OnCollisionEnter2D(Collision2D other){
		grounded = true;
	}

	public void OnCollisionExit2D(Collision2D other){
		grounded = false;
	}
}
