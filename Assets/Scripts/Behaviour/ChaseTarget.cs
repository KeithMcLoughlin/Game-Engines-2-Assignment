﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : SteeringBehaviour {

    public Boid target;
    Vector3 targetPos;

    public override Vector3 Calculate()
    {
        //chase if there is a target
        if (target != null)
        {
            float dist = Vector3.Distance(target.transform.position, transform.position);
            float time = dist / boid.maximumSpeed;

            targetPos = target.transform.position + (time * target.velocity);

            return boid.SeekForce(targetPos);
        }
        else
            return new Vector3(0, 0, 0);
    }
}
