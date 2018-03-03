using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPath : MonoBehaviour {

    public List<Vector3> waypoints = new List<Vector3>();
    public int next = 0;
    
    void Start()
    {
        waypoints.Clear();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            waypoints.Add(transform.GetChild(i).position);
        }
    }

    public Vector3 NextWaypoint()
    {
        return waypoints[next];
    }

    public void AdvanceToNext()
    {
        next = (next + 1) % waypoints.Count;
    }
}
