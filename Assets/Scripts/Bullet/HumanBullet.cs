using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBullet : Bullet {

    public void OnTriggerEnter(Collider other)
    {
        //if it hits an enemy ship, do damage to it
        if (other.gameObject.tag == "VasikShip")
        {
            other.gameObject.GetComponent<VasikShip>().ApplyDamage(Damage);
            GameObject.Destroy(this.gameObject);
        }

        //if it hits an obstacle or an enemys bullet, destroy this bullet
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "VasikBullet")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
