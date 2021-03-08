// Written by Igor Barbosa
// This filter class will find objects of the same flock and ignore others

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
public class FlockFilterSame : FlockFilterContext
{
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        // Iterate through original list of detected objects
        foreach(Transform item in original)
        {
            // Attempts to get the Flock Agent component of detected object
            // Will return null if the object does not have one
            FlockAgent itemCast = item.GetComponent<FlockAgent>();
            // Check if this is indeed a Flock Agent object
            // Check if they are also part of the same flock
            if (itemCast != null && itemCast.AgentFlock == agent.AgentFlock)
            {
                filtered.Add(item);
            }
        }

        return filtered;
    }
}
