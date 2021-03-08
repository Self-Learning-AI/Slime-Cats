using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/Filter/Obstacle Layer")]
public class FlockFilterObstacleLayer : FlockFilterContext
{
    public LayerMask mask;

    public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        // Iterate through original list of detected objects
        foreach (Transform item in original)
        {
            // Attempts to get the Flock Agent component of detected object
            // Will return null if the object does not have one
            FlockAgent itemCast = item.GetComponent<FlockAgent>();
            // Check if the object is an obstacle in the obstacle layer
            if (mask == (mask | (1 << item.gameObject.layer)))
            {
                filtered.Add(item);
            }
        }

        return filtered;
    }
}
