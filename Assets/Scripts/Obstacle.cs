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
        if (collision.gameObject.tag == "HumanBullet" ||
            collision.gameObject.tag == "VasikBullet")
        {
            GameObject.Destroy(collision.gameObject);
        }

        //todo if ship, damage it + push away
    }
}
