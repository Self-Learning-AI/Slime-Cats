// Written by Igor Barbosa
// This behaviour class faces all agents in the same general direction

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class FlockAlignmentBehaviour : FlockBehaviour
{

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // Stay on current allignment if there are no detected objects
        if (context.Count == 0)
        {
            return agent.transform.forward;
        }

        // Add the direction that each agent is facing and get the average look direction
        Vector3 alignmentMove = Vector3.zero;


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
            alignmentMove += (Vector3)item.transform.forward;
        }
        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
