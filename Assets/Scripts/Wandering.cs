using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public float speed = 1;
    public Vector3 destination;
    public float range = 6;
    public Rigidbody body;

    void Start()
    {
        Wander();
    }

    void FixedUpdate()
    {
        // this is called every frame
        // do move code here
        body.AddRelativeForce(destination * speed * Time.deltaTime);
        //transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
        if ((transform.position - destination).magnitude < 2)
        {
            Wander();
        }
    }

    void Wander()
    {
        destination = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), transform.position.y, Random.Range(transform.position.z - range, transform.position.z + range));

        transform.LookAt(destination);

    }
}
