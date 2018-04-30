using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dome : MonoBehaviour {
    
    //destroy bullets as they leave the dome
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HumanBullet" ||
            other.gameObject.tag == "VasikBullet")
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
