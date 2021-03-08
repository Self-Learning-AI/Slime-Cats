// Written by Igor Barbosa
// This behaviour class makes all agents follow a leader

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/FollowLeader")]
public class FlockFollowBehaviour : FlockBehaviour
{
    public GameObject leader;
    public float maxDistance = 3.0f;
    public Vector3 offset = new Vector3(-1.0f, 0.0f, -1.0f);

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector3 followMove = leader.transform.position + offset;
        float agentDistance = Vector3.Distance(agent.transform.position, leader.transform.position);

        if (agentDistance > maxDistance)
        {
            followMove -= agent.transform.position;
        }
        else
        {
            return Vector3.zero;
        }
        

        return followMove;
    }
}
