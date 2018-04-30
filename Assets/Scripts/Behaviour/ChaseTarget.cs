using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : SteeringBehaviour {

    public Boid target;
    Vector3 targetPos;

    public override Vector3 Calculate()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        float time = dist / boid.maxSpeed;

        targetPos = target.transform.position + (time * target.velocity);

        return boid.SeekForce(targetPos);
    }
}
