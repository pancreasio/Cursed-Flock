using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : BoidBehaviour
{
    public override Vector3 GetBehaviourForce(Boid targetBoid, List<Boid> neighborBoids, List<GameObject> threatList, List<GameObject> foodList, Vector3 nextWaypointPosition)
    {
        for (int i=0; i<foodList.Count; i++)
        {
            float distance = Vector3.Distance(targetBoid.transform.position, foodList[i].transform.position);
            if (distance < effectiveRange)
            {
                return (foodList[i].transform.position - targetBoid.transform.position).normalized * targetBoid.maxSpeed - targetBoid.velocity;
            }
        }
        return base.GetBehaviourForce(targetBoid, neighborBoids, threatList, foodList, nextWaypointPosition);
    }
}
