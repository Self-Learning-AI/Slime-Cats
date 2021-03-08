// Written by Igor Barbosa
// This behaviour class brings all agents closer together

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class FlockCohesionBehaviour : FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // Check if there are no neighbours, skip process
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        // Add all vectors and then get the average vector position
        Vector3 cohesionMove = Vector3.zero;

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

        // Iterate through the filtered agents
        foreach (Transform item in filteredContext)
        {
            cohesionMove += (Vector3)item.position;
        }
        cohesionMove /= context.Count;

        // Offset position to find middle point between detected objects 
        cohesionMove -= (Vector3)agent.transform.position;
        return cohesionMove;
    }

}
