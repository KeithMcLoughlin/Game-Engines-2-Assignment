using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dome : MonoBehaviour {
    
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HumanBullet" ||
            other.gameObject.tag == "VasikBullet")
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
