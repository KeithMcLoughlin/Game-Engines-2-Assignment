using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasikBullet : Bullet {

    public void OnTriggerEnter(Collider other)
    {
        //if it hits an enemy ship, do damage to it
        if (other.gameObject.tag == "HumanShip")
        {
            other.gameObject.GetComponent<HumanShip>().ApplyDamage(Damage);
            GameObject.Destroy(this.gameObject);
        }

        //if it hits an obstacle or an enemys bullet, destroy this bullet
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "HumanBullet")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
