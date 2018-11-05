using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public float parallaxSpeed; 

    private Transform cameraTransform;
    private Transform[] parallaxElements;
    private float lastCameraX; 


	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x; 
        parallaxElements = new Transform[transform.childCount];
        for (int i = 0; i < parallaxElements.Length; i++)
        {
            parallaxElements[i] = transform.GetChild(i); 
        }
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = cameraTransform.position.x - lastCameraX; 
        for (int i = 0; i < parallaxElements.Length; i++)
        {
            parallaxElements[i].position += Vector3.right * (deltaX * parallaxSpeed);
        }
        lastCameraX = cameraTransform.position.x; 
	}
}
