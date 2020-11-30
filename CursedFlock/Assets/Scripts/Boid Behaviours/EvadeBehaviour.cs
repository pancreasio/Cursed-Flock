using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeBehaviour : BoidBehaviour
{
    public override Vector3 GetBehaviourForce(Boid targetBoid, List<Boid> neighborBoids, List<GameObject> threatList, List<GameObject> foodList, Vector3 nextWaypointPosition)
    {
        for (int i = 0; i < threatList.Count; i++)
        {
            Vector3 threatPos = threatList[i].transform.position;
            if (Vector3.Distance(targetBoid.transform.position, threatPos) < effectiveRange)
            {
                Vector3 dirVector = targetBoid.transform.position - threatPos;
                dirVector = dirVector.normalized * targetBoid.maxSpeed;

                return dirVector * weight;
            }
        }
        return base.GetBehaviourForce(targetBoid, neighborBoids, threatList, foodList, nextWaypointPosition);
    }
}
