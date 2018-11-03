using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMover : MonoBehaviour {
    private float speed;

    private void Start()
    {
        speed = Random.Range(-5, 5);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);
	}
}
