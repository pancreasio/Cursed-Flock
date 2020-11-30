using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointBehaviour : BoidBehaviour
{
    public override Vector3 GetBehaviourForce(Boid targetBoid, List<Boid> neighborBoids, List<GameObject> threatList, List<GameObject> foodList, Vector3 nextWaypointPosition)
    {
        Vector3 resultantDirection = nextWaypointPosition - targetBoid.transform.position;
        Vector3 resultantDistance = resultantDirection.normalized - targetBoid.velocity;
        
        return resultantDistance;
    }
}
