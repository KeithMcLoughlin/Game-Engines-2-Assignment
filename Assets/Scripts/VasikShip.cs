using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class VasikShip : Ship {

    public GameObject VasikBulletPrefab;
    public GameObject BulletSpawnPosition; 

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(VasikBulletPrefab);
            bullet.transform.position = BulletSpawnPosition.transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.transform.parent = this.transform;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HumanBullet")
        {
            GameObject.Destroy(collision.gameObject);
            //take damage
            //if health < 0 die
        }
    }
}
