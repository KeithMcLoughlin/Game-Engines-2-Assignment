using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

    public float mass = 1;
    public float maximumSpeed = 10;
    public Vector3 velocity = Vector3.zero;
    Vector3 force = Vector3.zero;
    Vector3 acceleration = Vector3.zero;

    void Start()
    {
        behaviours.AddRange(GetComponents<SteeringBehaviour>());
    }

    public Vector3 SeekForce(Vector3 targetDest)
    {
        Vector3 toDest = targetDest - transform.position;
        toDest.Normalize();
        toDest *= maximumSpeed;
        
        return toDest - velocity;
    }

    Vector3 Calculate()
    {
        force = Vector3.zero;
        foreach (SteeringBehaviour b in behaviours)
        {
            if (b.isActiveAndEnabled)
            {
                force += b.Calculate() * b.weight;
                
            }
        }
        
        return force;
    }

    void Update()
    {
        force = Calculate();
        Vector3 newAcceleration = force / mass;

        float smoothRate = Mathf.Clamp(9.0f * Time.deltaTime, 0.15f, 0.4f) / 2.0f;
        acceleration = Vector3.Lerp(acceleration, newAcceleration, smoothRate);

        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maximumSpeed);

        Vector3 globalUp = new Vector3(0, 0.2f, 0);
        Vector3 accelUp = acceleration * 0.05f;
        Vector3 bankUp = accelUp + globalUp;
        smoothRate = Time.deltaTime * 3.0f;
        Vector3 tempUp = transform.up;
        tempUp = Vector3.Lerp(tempUp, bankUp, smoothRate);

        if (velocity.magnitude > 0.0001f)
        {
            transform.LookAt(transform.position + velocity, tempUp);
            velocity *= 0.99f;
        }
        transform.position += velocity * Time.deltaTime;
    }
}
