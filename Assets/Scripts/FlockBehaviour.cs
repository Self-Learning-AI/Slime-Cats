// Written by Igor Barbosa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviour : ScriptableObject
{
    /* This class creates abstract methods that the
     * behaviours will implement. It takes:
     * # A Flock Agent to calculate its move
     * # A list of Transforms for neighbouring agents
     *   or obstacles
     * # A Flock for information about the flock*/
    public abstract Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock);


    // Used to filter which agents are affected by the behaviour
    public FlockFilterContext filter;
    
}
