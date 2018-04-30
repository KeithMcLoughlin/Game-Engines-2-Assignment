using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasikBullet : Bullet {

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HumanShip")
        {
            //do damage
            GameObject.Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "HumanBullet")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
