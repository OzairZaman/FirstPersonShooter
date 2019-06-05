using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //base AI Class
    public float maxVelocity = 15f, maxDistance = 10f;
    public Vector3 velocity;
    public SteeringBehavior[] behaviours;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        behaviours = GetComponents<SteeringBehavior>();
    }

    private void Update()
    {
        //set force to zero
        Vector3 force = Vector3.zero;

        //step 1 loop through all the behaviours and get forces
        foreach (var behaviour in behaviours)
        {
            force += behaviour.GetForce(this);
        }
        //step 2 apply force to velocity
        velocity += force * Time.deltaTime;
        //step 2 limit velocity to max veocity
        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }
        //step 4 apply velocity to NavMeshAgent
        // navmesh will limit where we can go
        // stay with in the navmesh 
        // follow along the navmesh
        if (velocity.magnitude > 0)
        {
            //calculated position for next frame (using velocity)
            Vector3 desiredPosition = transform.position + velocity * Time.deltaTime;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(desiredPosition, out hit, maxDistance, -1)) // -1 = all areas (areaMask)
            {
                agent.SetDestination(hit.position);
            }
        }
    }
}
