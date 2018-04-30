using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float RotationSpeed = 0.0f;
    
	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
	}

    public void OnCollisionEnter(Collision collision)
    {
        //todo if ship, damage it + push away
    }
}
