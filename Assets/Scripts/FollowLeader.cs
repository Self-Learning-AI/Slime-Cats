using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLeader : MonoBehaviour
{
    public GameObject leader;
    public Rigidbody body;
    public float maxDistance = 3.0f;
    public float speed = 20.0f;
    public Vector3 offset = new Vector3(-1.0f, 0.0f, -1.0f);

    private void FixedUpdate()
    {
        CalculateMove();
    }

    public void CalculateMove()
    {
        Vector3 followMove = leader.transform.position + offset;
        float agentDistance = Vector3.Distance(transform.position, leader.transform.position);

        if (agentDistance > maxDistance)
        {
            followMove -= transform.position;
        }
        else
        {
            followMove = Vector3.zero;
        }
        followMove *= 2.0f;

        followMove.y = 0.0f;
        //transform.forward = followMove;
        transform.position += followMove * Time.deltaTime;
        //body.AddRelativeForce(followMove * speed * Time.deltaTime);

        transform.LookAt(leader.transform.position);
    }
}
