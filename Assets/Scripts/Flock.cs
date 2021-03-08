// Written by Igor Barbosa
// !Note that an agent refers to a cat and vice versa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flock : MonoBehaviour
{
    // public GameObject spawnPoint;
    // Prefab that will instantiate the Flock Agents
    public FlockAgent agentPrefab;
    // A list of Flock Agents where the instantiated prefabs are stored
    List<FlockAgent> agents = new List<FlockAgent>();
    // The given begaviour that the Flock Agent will follow
    public FlockBehaviour behaviour;

    // Default cat army size
    public int armySize = 3;
    // For populating agents within an area
    const float agentDensity = 0.1f;

    // Controls agent speeds in flock
    public float agentSpeed = 5.0f;
    public float maxSpeed = 5.0f;

    // A radius for agents to detect eachother and objects
    public float detectionRadius = 2.0f;
    // A radius for evading other agents and objects
    public float evasionRadius = 0.5f;

    // Used to compare values between agents
    // Saves some calculations on run time
    float sqrMaxSpeed;
    float sqrDetectionRadius;
    float sqrEvasionRadius;
    public float SqrEvasionRadius { get { return sqrEvasionRadius; } }
    public float spawnHeight = 1.0f;

    void Start()
    {
        // Get the square of max speed and radii
        sqrMaxSpeed = maxSpeed * maxSpeed;
        sqrDetectionRadius = detectionRadius * detectionRadius;
        sqrEvasionRadius = sqrDetectionRadius * evasionRadius * evasionRadius;

        // Instantiates the cat army
        for (int i = 0; i < armySize; i++)
        {
            // Create a new cat in  a random position inside a circle
            //FlockAgent newAgent = Instantiate(agentPrefab,
            //    Random.insideUnitSphere * armySize * agentDensity,
            //    Quaternion.Euler(Vector3.forward * Random.Range(0.0f, 360.0f)),
            //    transform);
            Vector3 nPosition = transform.position;
            nPosition.x += Random.Range(-10.0F, 10.0F);
            nPosition.z += Random.Range(-10.0F, 10.0F);
            FlockAgent newAgent = Instantiate(agentPrefab, nPosition, Quaternion.identity);

            // Name the newly created cat to make it easier to track them
            newAgent.name = "Cat " + i;
            // Initialise the new agent in their correct flock
            newAgent.Initialise(this);
            // Add the cat to the list of cats
            agents.Add(newAgent);

        }
    }


    void Update()
    {
        // Calculate move for each agent in the flock
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetDetectedObjects(agent);
            Vector3 move = behaviour.CalculateMove(agent, context, this);
            move *= agentSpeed;

            if (move.sqrMagnitude > sqrMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    public List<Transform> GetDetectedObjects(FlockAgent agent)
    {
        // Gets all objects colliding with the given Flock Agent
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, detectionRadius);

        foreach (Collider c in contextColliders)
        {
            // check if this is not our own collider
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }
}
