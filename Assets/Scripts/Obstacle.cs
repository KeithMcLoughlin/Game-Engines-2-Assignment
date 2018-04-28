using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float RotationSpeed = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
	}
}
