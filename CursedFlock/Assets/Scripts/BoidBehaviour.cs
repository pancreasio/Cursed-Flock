using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : MonoBehaviour
{
    [Range(0, 1)]
    public float weight;

    public enum BehaviourType
    {
        separation, allignment, cohesion, evasion, seeker, follower
    }

    public BehaviourType behaviour;

    public virtual Vector3 GetBehaviourForce(Boid targetBoid, List<Boid> neighbourBoids)
    {
        return Vector3.zero;
    }
}
