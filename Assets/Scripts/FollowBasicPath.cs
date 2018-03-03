using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBasicPath : SteeringBehaviour
{
    public BasicPath path;
    Vector3 nextWaypoint;

    public override Vector3 Calculate()
    {
        nextWaypoint = path.NextWaypoint();
        if (Vector3.Distance(transform.position, nextWaypoint) < 100)
        {
            path.AdvanceToNext();
        }
        
        return boid.SeekForce(nextWaypoint);
    }
}
