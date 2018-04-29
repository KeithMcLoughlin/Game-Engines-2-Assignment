using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed = 5;
	
	void Update ()
    {
        this.transform.Translate(0, 0, Speed * Time.deltaTime);
    }
}
