using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () {
		transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z + offset.z);
	}
}
