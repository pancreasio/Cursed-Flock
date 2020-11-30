using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public BoidManager parentManager;

    public Vector3 velocity;
    private Vector3 nextWaypointPosition;
    public float initialSpeed;
    public float maxSpeed;
    public float rotationSpeed;

    void Start()
    {
        velocity = (Random.rotation * transform.forward).normalized * initialSpeed;
    }

    void Update()
    {
        foreach (BoidBehaviour behaviour in parentManager.ActiveBoidBehaviours)
        {
            velocity += behaviour.GetBehaviourForce(this, parentManager.activeBoidList, parentManager.threatList, parentManager.foodList, nextWaypointPosition) * behaviour.weight;
        }

        transform.position += Vector3.ClampMagnitude(velocity, maxSpeed) * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Wall")
        {
            //transform.position = 2 * other.transform.position - transform.position;
            velocity *= -1;
        }
    }
}
