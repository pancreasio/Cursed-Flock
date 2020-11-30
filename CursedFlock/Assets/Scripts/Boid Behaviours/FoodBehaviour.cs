using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : BoidBehaviour
{
    public override Vector3 GetBehaviourForce(Boid targetBoid, List<Boid> neighborBoids, List<GameObject> threatList, List<GameObject> foodList, Vector3 nextWaypointPosition)
    {
        int bestFoodIndex = 0;
        float closestFood = float.MaxValue;
        for (int i=0; i<foodList.Count; i++)
        {
            float distance = Vector3.Distance(targetBoid.transform.position, foodList[i].transform.position);
            if (distance < effectiveRange && distance<closestFood)
            {
                closestFood = distance;
                bestFoodIndex = i;
            }
        }

        if (closestFood != float.MaxValue)
        {
            Vector3 resultantDirection = foodList[bestFoodIndex].transform.position - targetBoid.transform.position;
            Vector3 resultantDistance = resultantDirection.normalized - targetBoid.velocity;

            return resultantDistance;
        }

        return base.GetBehaviourForce(targetBoid, neighborBoids, threatList, foodList, nextWaypointPosition);
    }
}
