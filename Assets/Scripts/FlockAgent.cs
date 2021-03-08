// Written by Igor Barbosa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We require a collider to detect neighbouring objects
[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }
    
    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }

    public void Initialise(Flock flock)
    {
        agentFlock = flock;
    }

    // Turn agent towards destination and then move
    public void Move(Vector3 velocity)
    {
        //velocity.y = transform.position.y;
        velocity.y = 0.0f;
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }
}
