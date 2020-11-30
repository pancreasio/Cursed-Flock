using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehaviour : BoidBehaviour
{
    public override Vector3 GetBehaviourForce(Boid targetBoid, List<Boid> neighborBoids, List<GameObject> threatList, List<GameObject> foodList, Vector3 nextWaypointPosition)
    {
        Vector3 resultantVelocity = Vector3.zero;
        int neighbourCount = 0;
        foreach (Boid neighbor in neighborBoids)
        {
            if (neighbor == targetBoid)
                continue;

            if ((targetBoid.transform.position - neighbor.transform.position).magnitude < effectiveRange)
            {
                resultantVelocity += neighbor.velocity;
                neighbourCount++;
            }
        }

        if (neighbourCount > 0)
        {
            resultantVelocity = resultantVelocity.normalized * targetBoid.maxSpeed;
            return resultantVelocity;
        }
        return base.GetBehaviourForce(targetBoid, neighborBoids, threatList, foodList, nextWaypointPosition);
    }
}
