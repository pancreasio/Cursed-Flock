using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : MonoBehaviour
{
    [Range(0, 20)]
    public float weight;

    public float effectiveRange;

    public virtual Vector3 GetBehaviourForce(Boid targetBoid, List<Boid> neighborBoids, List<GameObject> threatList, List<GameObject> foodList, Vector3 nextWaypointPosition)
    {
        return Vector3.zero;
    }
}
