using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class AvoidCloseObstacles : SteeringBehaviour {
    
    public List<GameObject> ObjectsInVicinity = new List<GameObject>();

    public override Vector3 Calculate()
    {
        force = Vector3.zero;

        ObjectsInVicinity.RemoveAll(item => item == null);
        //apply force from each nearby object
        foreach (var nearbyObject in ObjectsInVicinity)
        {
            force += CalculateSceneAvoidanceForce(nearbyObject);
        }
        
        return force;
    }

    Vector3 CalculateSceneAvoidanceForce(GameObject nearbyObject)
    {
        //if the nearby object has been destroyed
        if(nearbyObject == null)
        {
            return new Vector3(0, 0, 0);
        }

        Vector3 f = Vector3.zero;

        Vector3 fromTarget = transform.position - nearbyObject.transform.position;
        float dist = Vector3.Distance(transform.position, nearbyObject.transform.position);

        //calculate force to move away from nearby object
        f += fromTarget * (10 / dist);

        return f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "VasikBullet" || other.gameObject.tag == "HumanBullet" || other.gameObject == this.gameObject
            || other.gameObject.tag == "Dome")
            return;
        
        //add this to nearby objects
        ObjectsInVicinity.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        //remove this from nearby objects
        if (ObjectsInVicinity.Contains(other.gameObject))
            ObjectsInVicinity.Remove(other.gameObject);
    }
}
