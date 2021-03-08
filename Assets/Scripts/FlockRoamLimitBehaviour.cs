// Written by Igor Barbosa
// This behaviour class keeps the agents within a given radius

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/RoamLimit")]
public class FlockRoamLimitBehaviour : FlockBehaviour
{
    public Vector3 center;
    public float radius = 20.0f;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector3 centerOffset = center - agent.transform.position;
        float r = centerOffset.magnitude / radius;
        
        if (r < 0.9f)
        {
            return Vector3.zero;
        }

        return centerOffset * r * r;
    }
}
