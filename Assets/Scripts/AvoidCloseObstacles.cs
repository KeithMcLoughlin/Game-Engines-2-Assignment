using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class AvoidCloseObstacles : SteeringBehaviour {
    
    public List<GameObject> ObjectsInVicinity = new List<GameObject>();

    public override Vector3 Calculate()
    {
        force = Vector3.zero;

        foreach (var nearbyObject in ObjectsInVicinity)
        {
            force += CalculateSceneAvoidanceForce(nearbyObject);
        }
        
        return force;
    }

    Vector3 CalculateSceneAvoidanceForce(GameObject nearbyObject)
    {
        if(nearbyObject == null)
        {
            return new Vector3(0, 0, 0);
        }

        Vector3 f = Vector3.zero;

        Vector3 fromTarget = transform.position - nearbyObject.transform.position;
        float dist = Vector3.Distance(transform.position, nearbyObject.transform.position);

        f += fromTarget * (10 / dist);

        return f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "VasikBullet" || other.gameObject.tag == "HumanBullet" || other.gameObject == this.gameObject)
            return;
        
        ObjectsInVicinity.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (ObjectsInVicinity.Contains(other.gameObject))
            ObjectsInVicinity.Remove(other.gameObject);
    }
}
