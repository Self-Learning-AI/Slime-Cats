// Written by Igor Barbosa
// This behaviour class moves agents away from each other and objects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
public class FlockAvoidanceBehaviour : FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // Check if there are no neighbours, skip process
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        // Number of agents/objects to avoid
        int avoidCount = 0;

        // Check if there is a flock filter to apply
        List<Transform> filteredContext;
        if (filter == null)
        {
            filteredContext = context;
        }
        else
        {
            filteredContext = filter.Filter(agent, context);
        }

        // Add all vectors and then get the average vector position
        Vector3 avoidanceMove = Vector3.zero;
        // Iterate through the filtered agents
        foreach (Transform item in filteredContext)
        {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.SqrEvasionRadius)
            {
                avoidCount++;
                // Offset from player position
                avoidanceMove += agent.transform.position - item.position;
            }
            
        }

        // Divide by total number of objects to avoid if there are any for the average
        if (avoidCount > 0)
        {
            avoidanceMove /= avoidCount;
        }
        //avoidanceMove.y = agent.transform.position.y;
        return avoidanceMove;
    }
}
