using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionBehaviour : BoidBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        behaviour = BehaviourType.cohesion;
    }

    public override Vector3 GetBehaviourForce(Boid targetBoid, List<Boid> neighbourBoids)
    {
        return base.GetBehaviourForce(targetBoid, neighbourBoids);
    }
}
