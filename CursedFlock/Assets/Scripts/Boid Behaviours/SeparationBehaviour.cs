using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationBehaviour : BoidBehaviour
{
    public float maxSeparationSpeed;
    public override Vector3 GetBehaviourForce(Boid targetBoid, List<Boid> neighborBoids, List<GameObject> threatList, List<GameObject> foodList, Vector3 nextWaypointPosition)
    {
        Vector3 resultantVelocity = Vector3.zero;
        int neighbourCount = 0;
        foreach (Boid neighbor in neighborBoids)
        {
            if (neighbor == targetBoid)
                continue;

            if (targetBoid == null || neighbor == null)
            {
                return base.GetBehaviourForce(targetBoid, neighborBoids, threatList, foodList, nextWaypointPosition);
            }

            Vector3 separationVector = targetBoid.transform.position - neighbor.transform.position;

            if (separationVector.magnitude < effectiveRange)
            {
                resultantVelocity += separationVector.normalized * maxSeparationSpeed / separationVector.magnitude;
                neighbourCount++;
            }
        }

        if (neighbourCount > 0)
        {
            resultantVelocity /= neighbourCount;
            Vector3 resultantForce = resultantVelocity - targetBoid.velocity;
            return resultantForce;
        }

        return base.GetBehaviourForce(targetBoid, neighborBoids, threatList, foodList, nextWaypointPosition);
    }
}
