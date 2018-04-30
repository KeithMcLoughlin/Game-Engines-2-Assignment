using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float RotationSpeed = 0.0f;
    
	void Update ()
    {
        //rotate around y axis
        transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
	}
}
