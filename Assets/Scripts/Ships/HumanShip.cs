using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class HumanShip : Ship {
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "VasikBullet")
        {
            GameObject.Destroy(collision.gameObject);
            //take damage
            //if health < 0 die
        }
    }
}
